using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonster : NormalMonsterObject
{
    protected override IEnumerator _TriggerGetDamage(float damage)
    {
        isInvincible = true;

        SoundManager.instance.sfxPlayer.Play(Sfx.BoxyGetDamage);
        curHp -= damage;
        if (curHp <= 0f)
            _Die();
        else
            _animator.SetTrigger(AnimatorID.Trigger.Hit);

        yield return _wfs_invincible;
        isInvincible = false;
    }
    protected override void _RushToTarget()
    {
        _navMeshAgent.stoppingDistance = data.stoppingDistance;
        if (hasTarget)
        {
            SoundManager.instance.sfxPlayer.Play(Sfx.BoxyWalk);
            _navMeshAgent.destination = target.transform.position;
        }
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

        SoundManager.instance.sfxPlayer.Play(Sfx.BoxyAttack);
        int idx = Random.Range(0, _attackClips.Length);
        _animator.SetTrigger(AnimatorID.Trigger.Attacks[idx]);
        yield return new WaitForSeconds(_attackClips[idx].length + 1f);

        _navMeshAgent.destination = hasTarget ? target.transform.position : transform.position;
        isAttacking = false;
        _attackCor = null;
    }
    protected override IEnumerator _DieRoutine()
    {
        SoundManager.instance.sfxPlayer.Play(Sfx.BoxyDead);
        _animator.SetTrigger(AnimatorID.Trigger.Die);
        yield return new WaitForSeconds(_destroyTime);
        ObjectPools.instance.normalMonsterPool.Put(gameObject);
    }
}
