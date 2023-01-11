using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specter : NormalMonsterObject
{
    protected override IEnumerator _TriggerGetDamage(float damage)
    {
        isInvincible = true;

        SoundManager.instance.sfxPlayer.Play(Sfx.GhostGetDamage);
        curHp -= damage;
        if (curHp <= 0f)
            _Die();
        else
            _animator.SetTrigger(AnimatorID.Trigger.Hit);

        yield return _wfs_invincible;
        isInvincible = false;
    }
    protected override IEnumerator _Attack()
    {
        isAttacking = true;

        SoundManager.instance.sfxPlayer.Play(Sfx.GhostAttack);
        int idx = Random.Range(0, _attackClips.Length);
        _animator.SetTrigger(AnimatorID.Trigger.Attacks[idx]);
        yield return new WaitForSeconds(_attackClips[idx].length + 1f);

        _navMeshAgent.destination = hasTarget ? target.transform.position : transform.position;
        isAttacking = false;
        _attackCor = null;
    }
    protected override IEnumerator _DieRoutine()
    {
        SoundManager.instance.sfxPlayer.Play(Sfx.GhostDead);
        _animator.SetTrigger(AnimatorID.Trigger.Die);
        yield return new WaitForSeconds(_destroyTime);
        ObjectPools.instance.normalMonsterPool.Put(gameObject);
    }
}
