using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonsterObject를 상속하는 하위 클래스
/// </summary>
public class NormalMonsterObject : MonsterObject
{
    protected override void _RushToTarget()
    {
        _navMeshAgent.stoppingDistance = data.stoppingDistance;
        if (hasTarget)
            _navMeshAgent.destination = target.transform.position;
        else return;

        var lookDir2D = target.transform.position;
        lookDir2D.y = transform.position.y;
        transform.LookAt(lookDir2D);

        if (isAttackable && _attackCor == null)
            _attackCor = StartCoroutine(_Attack());
    }
    protected override IEnumerator _Attack()
    {
        isAttacking = true;

        int idx = Random.Range(0, _attackClips.Length);
        _animator.SetTrigger(AnimatorID.Trigger.Attacks[idx]);
        yield return new WaitForSeconds(_attackClips[idx].length + 1f);

        _navMeshAgent.destination = hasTarget ? target.transform.position : transform.position;
        isAttacking = false;
        _attackCor = null;
    }
    protected override void _LateGetDamage()
    {
        throw new System.NotImplementedException();
    }
    protected override IEnumerator _LateDie()
    {
        _animator.SetTrigger(AnimatorID.Trigger.Die);
        yield return new WaitForSeconds(_destroyTime);
        ObjectPools.instance.normalMonsterPool.Put(gameObject);
    }
}
