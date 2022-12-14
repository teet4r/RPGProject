using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBoss : BossMonsterObject
{
    protected override void Awake()
    {
        base.Awake();

        _attackPatterns.Add(GetComponent<GolemPattern1>());
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
    protected override IEnumerator _Attack()
    {
        // 플레이어 자리까지 회전
        // 상태 잠시 변경
        isAttacking = true;
        _navMeshAgent.isStopped = true;
        yield return _rotate3D.StartCoroutine(_rotate3D.Rotate(target.transform.position));

        // 공격
        int idx = Random.Range(0, _attackClips.Length);
        _animator.SetTrigger(AnimatorID.Trigger.Attacks[idx]);
        _attackPatterns[idx].Attack(this, target.transform);

        // 공격 애니메이션 + 1초가 끝날 때까지 대기
        yield return new WaitForSeconds(_attackClips[idx].length + 1f);

        // 상태 원위치
        _navMeshAgent.isStopped = false;
        _navMeshAgent.destination = hasTarget ? target.transform.position : transform.position;
        isAttacking = false;
        _attackCor = null;
    }

    List<IAttackPattern> _attackPatterns = new List<IAttackPattern>();
}
