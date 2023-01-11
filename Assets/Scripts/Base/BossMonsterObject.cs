using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonsterObject�� ����ϴ� ���� Ŭ����
/// </summary>
[RequireComponent(typeof(Rotate3D))]
public abstract class BossMonsterObject : MonsterObject
{
    protected override void Awake()
    {
        base.Awake();

        _rotate3D = GetComponent<Rotate3D>();
    }
    protected override void _RushToTarget()
    {
        _navMeshAgent.stoppingDistance = data.stoppingDistance;
        if (hasTarget)
            _navMeshAgent.destination = target.transform.position;
        else return;

        if (isAttackable && _attackCor == null)
            _attackCor = StartCoroutine(_Attack());
    }
    protected override IEnumerator _DieRoutine()
    {
        _animator.SetTrigger(AnimatorID.Trigger.Die);
        yield return new WaitForSeconds(_destroyTime);
        ObjectPools.instance.bossMonsterPool.Put(gameObject);
    }

    protected Rotate3D _rotate3D = null;
}
