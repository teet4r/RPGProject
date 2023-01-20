using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : NormalMonsterObject
{
    protected override void Awake()
    {
        base.Awake();

        _attackPatterns.Add(GetComponent<DragonPattern1>());
        _attackPatterns.Add(GetComponent<DragonPattern2>());
    }

    protected override IEnumerator _AttackRoutine()
    {
        _navMeshAgent.destination = Target.transform.position;
        _navMeshAgent.stoppingDistance = data.stoppingDistance;

        while (!IsReachedUnderDistance())
            yield return null;

        if (!IsAttackable) yield break;

        int idx = Random.Range(0, _attackClips.Length);
        _animator.SetTrigger(AnimatorID.Trigger.Attacks[idx]);
        _attackPatterns[idx].Attack(this, Target.transform);
    }

    List<IAttackPattern> _attackPatterns = new List<IAttackPattern>();
}
