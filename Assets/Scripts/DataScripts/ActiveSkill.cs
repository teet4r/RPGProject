using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActiveSkill", menuName = "Skill/Active")]
public class ActiveSkill : Skill
{
    // 작성자 : 김두현
    [SerializeField] float damageRate; // 0 레벨 기준 스킬 데미지
    [SerializeField] float damageRateAdd; // 스킬 레벨업시 증가하는 데미지

    [SerializeField] float defenseRate; // 증가하는 방어율

    [SerializeField] float coolTime; // 스킬 재사용 대기시간

    public float DamageRate { get { return damageRate; } }
    public float DamageRateAdd { get { return damageRateAdd; } }

    public float DefenseRate { get { return defenseRate; } }

    public float CoolTime { get { return coolTime; } }
}