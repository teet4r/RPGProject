using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMageBoss : BossMonsterObject
{
    protected override void Awake()
    {
        base.Awake();

        _attackPatterns.Add(GetComponent<EvilMagePattern1>());
        _attackPatterns.Add(GetComponent<EvilMagePattern2>());
    }

    protected override IEnumerator _AttackRoutine()
    {
        _navMeshAgent.destination = Target.transform.position;
        _navMeshAgent.stoppingDistance = data.stoppingDistance;

        while (!IsReachedUnderDistance())
            yield return null;

        if (!IsAttackable) yield break;

        // 플레이어 자리 쳐다보기
        _navMeshAgent.isStopped = true;
        yield return _rotate3D.StartCoroutine(_rotate3D.Rotate(Target.transform.position));

        if (!IsAttackable) yield break;

        // 공격
        int idx = Random.Range(0, _attackClips.Length);
        _animator.SetTrigger(AnimatorID.Trigger.Attacks[idx]);
        _attackPatterns[idx].Attack(this, Target.transform);
    }

    List<IAttackPattern> _attackPatterns = new List<IAttackPattern>();
}
