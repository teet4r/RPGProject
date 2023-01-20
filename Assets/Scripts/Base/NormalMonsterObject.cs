using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonsterObject를 상속하는 하위 클래스
/// </summary>
public class NormalMonsterObject : MonsterObject
{
    //protected override void _Rush()
    //{
    //    base._Rush();

    //    // 타겟을 계속 쳐다 봄
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
