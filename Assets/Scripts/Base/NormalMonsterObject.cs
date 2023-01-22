using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonsterObject�� ����ϴ� ���� Ŭ����
/// </summary>
public class NormalMonsterObject : MonsterObject
{
    protected override IEnumerator _AttackRoutine()
    {
        _navMeshAgent.destination = Target.transform.position;
        _navMeshAgent.stoppingDistance = data.stoppingDistance;

        while (!IsReachedUnderDistance())
            yield return null;

        if (!IsAttackable) yield break;

        // ����
        int idx = Random.Range(0, _attackClips.Length);
        _animator.SetTrigger(AnimatorID.Trigger.Attacks[idx]);
    }
    //protected override void _Rush()
    //{
    //    base._Rush();

    //    // Ÿ���� ��� �Ĵ� ��
    //    var lookDir2D = Target.transform.position;
    //    lookDir2D.y = transform.position.y;
    //    transform.LookAt(lookDir2D);
    //}

    //protected override void _Attack()
    //{
    //    int idx = Random.Range(0, _attackClips.Length);
    //    _animator.SetTrigger(AnimatorID.Trigger.Attacks[idx]);
    //}
}
