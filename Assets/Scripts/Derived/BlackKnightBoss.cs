using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnightBoss : BossMonsterObject
{
    protected override void Awake()
    {
        base.Awake();

        _attackPatterns.Add(GetComponent<BlackKnightPattern1>());
    }

    protected override IEnumerator _AttackRoutine()
    {
        base._AttackRoutine();

        // 플레이어 자리 쳐다보기
        _navMeshAgent.isStopped = true;
        yield return _rotate3D.StartCoroutine(_rotate3D.Rotate(Target.transform.position));

        // 공격
        int idx = Random.Range(0, _attackClips.Length);
        _animator.SetTrigger(AnimatorID.Trigger.Attacks[idx]);
        _attackPatterns[idx].Attack(this, Target.transform);
    }

    List<IAttackPattern> _attackPatterns = new List<IAttackPattern>();
}
