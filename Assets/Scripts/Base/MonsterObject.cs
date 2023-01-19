using System.Collections;
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
    public Player Target
    {
        get
        {
            return Player.instance;
        }
    }
    public bool HasTarget
    {
        get
        {
            return IsAlive && Target != null && Target.gameObject.activeInHierarchy && Target.IsAlive;
        }
    }
    public bool IsReachedToTargetPosition
    {
        get
        {
            return HasTarget && _navMeshAgent.remainingDistance <= 0.05f;
        }
    }
    public bool HasPathToEnemy // 적에게 도달할 수 있는 길이 있을 때
    {
        get
        {
            return
                HasTarget &&
                _SetPath(Target.transform.position) &&
                _navMeshPath.status == NavMeshPathStatus.PathComplete &&
                _navMeshAgent.remainingDistance <= data.recognitionDistance;
        }
    }
    public bool IsAttackable // 공격 가능할 때
    {
        get
        {
            bool isAttackable = false;
            if (HasPathToEnemy &&
                _navMeshAgent.remainingDistance <= data.stoppingDistance + 1f &&
                Time.time - _prevAttackTime >= data.attackRate)
            {
                isAttackable = true;
                _prevAttackTime = Time.time;
            }
            return isAttackable;
        }
    }
    public MonsterData data = null; // 몬스터 데이터 컨테이너

    [Header("----- Components -----")]
    [SerializeField] protected Collider _bodyCollider = null;
    [SerializeField] protected Animator _animator = null;
    [SerializeField] protected NavMeshAgent _navMeshAgent = null;
    [SerializeField] protected Rigidbody _rigidbody = null;

    [Header("----- Animations -----")]
    [SerializeField] protected AnimationClip[] _attackClips = null;

    [Header("----- Drop Item -----")]
    [SerializeField] string _itemName = null;
    [SerializeField] string _itemDropSoundName = null;

    Coroutine _moveCor = null;
    Coroutine _patrolCor = null;
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

        _StartMove();
    }

    protected override void Update()
    {
        base.Update();

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

        _StopPatrol();
        _StopMove();

        _DropItem();
    }
    


    void _StartMove()
    {
        if (_moveCor == null)
            _moveCor = StartCoroutine(_MoveRoutine());
    }

    void _StopMove()
    {
        if (_moveCor == null) return;

        StopCoroutine(_moveCor);
        _moveCor = null;
    }

    IEnumerator _MoveRoutine()
    {
        while (IsAlive)
        {
            // 적까지 도달할 수 있는 경로가 있다면
            if (HasPathToEnemy)
            {
                _StopPatrol();

                _navMeshAgent.destination = Target.transform.position;
                _navMeshAgent.stoppingDistance = data.stoppingDistance;
                _Attack();
            }
            else
            {
                _navMeshAgent.destination = transform.position;
                _navMeshAgent.stoppingDistance = 0f;
                _StartPatrol();
            }
            yield return null;
        }
    }
    


    void _StartPatrol()
    {
        if (_patrolCor == null)
            _patrolCor = StartCoroutine(_PatrolRoutine());
    }

    void _StopPatrol()
    {
        if (_patrolCor == null) return;

        StopCoroutine(_patrolCor);
        _patrolCor = null;
    }

    IEnumerator _PatrolRoutine()
    {
        while (IsAlive)
        {
            // 도착했을 때
            if (IsReachedToTargetPosition)
            {
                yield return new WaitForSeconds(Random.Range(0f, 7f));
                _navMeshAgent.destination = Algorithm.GetRandomPointOnNavMesh(transform.position, Random.Range(0f, data.patrolDistance));
            }
            else yield return null;
        }
    }



    protected virtual void _Attack()
    {
        if (!IsReachedToTargetPosition) return;
    }



    bool _SetPath(Vector3 targetPosition)
    {
        if (_navMeshAgent.CalculatePath(targetPosition, _navMeshPath) && _navMeshAgent.SetPath(_navMeshPath))
            return true;
        return false;
    }

    void _DropItem()
    {
        SoundManager.instance.sfxPlayer.Play(_itemDropSoundName);
        _MakeItem();
    }

    void _MakeItem()
    {
        var item = PoolManager.instance.Get(_itemName);
        item.transform.position = transform.position + Vector3.up * 3f;
        item.SetActive(true);
    }
}
