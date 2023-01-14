using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonsterObject를 상속하는 하위 클래스
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
    protected override void _LateGetDamage()
    {
        throw new System.NotImplementedException();
    }
    protected override IEnumerator _LateDie()
    {
        _animator.SetTrigger(AnimatorID.Trigger.Die);
        yield return new WaitForSeconds(_destroyTime);
        PoolManager.instance.Get("BossPool").Put(gameObject);
    }

    protected Rotate3D _rotate3D = null;
}
