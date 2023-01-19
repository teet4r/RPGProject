using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonsterObject�� ����ϴ� ���� Ŭ����
/// </summary>
public class NormalMonsterObject : MonsterObject
{
    protected override void _Attack()
    {
        var lookDir2D = Target.transform.position;
        lookDir2D.y = transform.position.y;
        transform.LookAt(lookDir2D);

        int idx = Random.Range(0, _attackClips.Length);
        _animator.SetTrigger(AnimatorID.Trigger.Attacks[idx]);
    }
}
