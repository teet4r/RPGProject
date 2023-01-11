using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// LifeObject�� ����ϴ� ���� Ŭ����
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public abstract class MonsterObject : LifeObject
{
    protected override void Awake()
    {
        base.Awake();

        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator= GetComponent<Animator>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();

        isAttacking = false;

        _bodyCollider.isTrigger = true;
        _bodyCollider.enabled = true;

        _patrolCor = null;
        _attackCor = null;

        _prevAttackTime = 0f;

        _navMeshAgent.isStopped = false;
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

        _animator.SetBool(AnimatorID.Bool.IsWalking, isWalking);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            player.GetDamage(data.damage);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            player.GetDamage(data.damage);
    }

    protected override IEnumerator _TriggerGetDamage(float damage)
    {
        isInvincible = true;

        curHp -= damage;
        if (curHp <= 0f)
            _Die();
        else
            _animator.SetTrigger(AnimatorID.Trigger.Hit);

        yield return _wfs_invincible;
        isInvincible = false;
    }
    protected override void _UpdateStates()
    {
        base._UpdateStates();
    }
    protected override void _Die()
    {
        base._Die();

        _navMeshAgent.isStopped = true;
        if (_patrolCor != null)
        {
            StopCoroutine(_patrolCor);
            _patrolCor = null;
        }
        _bodyCollider.enabled = false;

        _DropItem(_item);

        StartCoroutine(_DieRoutine());
    }
    protected virtual void _Move()
    {
        if (!isAlive) return;

        if (isRecognized)
        {
            if (_patrolCor != null)
            {
                StopCoroutine(_patrolCor);
                _patrolCor = null;
            }
            _RushToTarget();
        }
        else
        {
            if (_patrolCor == null)
                _patrolCor = StartCoroutine(_Patrol(transform.position));
        }
    }
    protected virtual IEnumerator _Patrol(Vector3 startPosition)
    {
        _navMeshAgent.destination = startPosition;
        _navMeshAgent.stoppingDistance = 0f;

        while (true)
        {
            // �������� ��
            if (_navMeshAgent.remainingDistance < 0.01f)
            {
                yield return new WaitForSeconds(Random.Range(0f, 7f));
                _navMeshAgent.destination = Algorithm.GetRandomPointOnNavMesh(transform.position, Random.Range(0f, data.patrolDistance));
            }
            else yield return null;
        }
    }
    protected abstract void _RushToTarget();
    protected abstract IEnumerator _Attack();
    IEnumerator _DieRoutine()
    {
        _animator.SetTrigger(AnimatorID.Trigger.Die);
        yield return new WaitForSeconds(_destroyTime);
        ObjectPools.instance.normalMonsterPool.Put(gameObject);
    }
    protected virtual void _DropItem(GameObject itemPrefab)
    {
        if (itemPrefab == null) return;

        Instantiate(itemPrefab, transform.position, itemPrefab.transform.rotation);
    }

    public Player target
    {
        get { return Player.instance; }
    }
    public bool hasTarget
    {
        get
        {
            return isAlive && target != null && target.gameObject.activeSelf && target.isAlive;
        }
    }
    public bool isRecognized // �÷��̾ �þ߿� ���� ��
    {
        get
        {
            return
                isAlive && 
                hasTarget &&
                Vector3.Distance(target.transform.position, transform.position) <= data.recognitionDistance;
        }
    }
    public bool isAttackable// ���� ������ ��
    {
        get
        {
            bool _isAttackable = false;
            if (isAlive &&
                hasTarget &&
                Vector3.Distance(target.transform.position, transform.position) <= data.stoppingDistance + 1f &&
                Time.time - _prevAttackTime >= data.attackRate) 
            {
                _isAttackable = true;
                _prevAttackTime = Time.time;
            }
            else
                _isAttackable = false;
            return _isAttackable;
        }
    }
    public bool isAttacking { get; protected set; } // ���� ���� �� true
    public MonsterData data = null; // ���� ������ �����̳�
    [SerializeField] protected AnimationClip[] _attackClips;
    [SerializeField] protected float _destroyTime = 5f;
    [SerializeField] protected Collider _bodyCollider = null;
    [SerializeField] protected GameObject _item = null;
    protected Animator _animator = null;
    protected NavMeshAgent _navMeshAgent = null;
    protected Rigidbody _rigidbody = null;
    protected Coroutine _patrolCor = null;
    protected Coroutine _attackCor = null;
    float _prevAttackTime = 0f;
}
