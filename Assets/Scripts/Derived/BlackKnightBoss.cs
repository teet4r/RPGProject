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

        // �÷��̾� �ڸ� �Ĵٺ���
        _navMeshAgent.isStopped = true;
        yield return _rotate3D.StartCoroutine(_rotate3D.Rotate(Target.transform.position));

        // ����
        int idx = Random.Range(0, _attackClips.Length);
        _animator.SetTrigger(AnimatorID.Trigger.Attacks[idx]);
        _attackPatterns[idx].Attack(this, Target.transform);
    }

    List<IAttackPattern> _attackPatterns = new List<IAttackPattern>();
}
