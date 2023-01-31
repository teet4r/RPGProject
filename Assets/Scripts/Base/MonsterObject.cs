using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// LifeObject를 상속하는 하위 클래스
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public abstract class MonsterObject : LifeObject
{
    public MonsterData data = null; // 몬스터 데이터 컨테이너
    
    protected Player Target
    {
        get
        {
            return Player.instance;
        }
    }
    protected bool HasTarget
    {
        get
        {
            return IsAlive && Target != null && Target.gameObject.activeInHierarchy && Target.IsAlive;
        }
    }
    protected bool HasPathToTarget // 타겟에게 도달할 수 있는 길이 있을 때
    {
        get
        {
            return
                HasTarget &&
                _navMeshAgent.CalculatePath(Target.transform.position, _navMeshPath) &&
                _navMeshAgent.SetPath(_navMeshPath) &&
                _navMeshPath.status == NavMeshPathStatus.PathComplete;
        }
    }
    protected bool IsRecognizedTarget
    {
        get
        {
            return HasPathToTarget && IsReachedUnderDistance(data.recognitionDistance);
        }
    }
    protected bool IsAttackable // 공격 가능할 때
    {
        get
        {
            bool isAttackable = false;
            if (IsRecognizedTarget &&
                IsReachedUnderDistance(data.stoppingDistance + 1f) &&
                Time.time - _prevAttackTime >= data.attackRate)
            {
                isAttackable = true;
                _prevAttackTime = Time.time;
            }
            return isAttackable;
        }
    }

    [Header("----- Components -----")]
    [SerializeField] protected Collider _bodyCollider = null;
    [SerializeField] protected Animator _animator = null;
    [SerializeField] protected NavMeshAgent _navMeshAgent = null;
    [SerializeField] protected Rigidbody _rigidbody = null;

    [Header("----- Animations -----")]
    [SerializeField] protected AnimationClip[] _attackClips = null;

    Coroutine _attackCor = null;
    NavMeshPath _navMeshPath;
    float _prevAttackTime;



    protected override void Awake()
    {
        base.Awake();

        _navMeshPath = new NavMeshPath();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _bodyCollider.isTrigger = true;

        _prevAttackTime = 0f;

        _navMeshAgent.stoppingDistance = data.stoppingDistance;
        _navMeshAgent.autoBraking = false;
        _navMeshAgent.speed = data.moveSpeed;
        _navMeshAgent.angularSpeed = 360f;
        _navMeshAgent.acceleration = 50f;
    }

    protected override void Update()
    {
        base.Update();

        _Move();

        _animator.SetBool(AnimatorID.Bool.IsWalking, IsWalking);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player) && player.IsAlive)
            player.GetDamage(data.damage);
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player) && player.IsAlive)
            player.GetDamage(data.damage);
    }



    protected override void _Die()
    {
        base._Die();

        _navMeshAgent.isStopped = true;
    }

    protected bool IsReachedUnderDistance(float distance = 0.05f)
    {
        return _navMeshAgent.remainingDistance <= distance;
    }


    void _Move()
    {
        // 공격할 수 있는 상태가 되면
        if (IsAttackable)
        {
            _StartAttack();
        }
        else
        {
            _StopAttack();
        }
    }

    /// <summary>
    /// 대상에게 달려간 후 공격
    /// </summary>
    void _StartAttack()
    {
        if (_attackCor != null) return;

        _attackCor = StartCoroutine(_AttackRoutine());
    }

    void _StopAttack()
    {
        if (_attackCor == null) return;

        StopCoroutine(_attackCor);
        _attackCor = null;
    }

    protected abstract IEnumerator _AttackRoutine();
}
