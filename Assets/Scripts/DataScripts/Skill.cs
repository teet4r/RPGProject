using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill/Skill")]
public class Skill : ScriptableObject
{
    // 작성자 : 김두현
    [SerializeField] string skillName; // 스킬 이름
    [SerializeField] Sprite skillImage; // 스킬 이미지

    [SerializeField] int skillMaxLevel; // 스킬 최대 레벨
    [SerializeField] int skillNeedLevel; // 스킬 습득에 필요한 레벨

    [SerializeField] float damageRate; // 0 레벨 기준 스킬 데미지 - 500% 는 5.0f
    [SerializeField] float damageRateAdd; // 스킬 레벨업시 증가하는 데미지

    [SerializeField] float coolTime; // 스킬 재사용 대기시간

    public string SkillName { get { return skillName; } }
    public Sprite SkillImage { get { return skillImage; } }

    public int SkillMaxLevel { get { return skillMaxLevel; } } 
    public int SkillNeedLevel { get { return skillNeedLevel; } }

    public float DamageRate { get { return damageRate; } }
    public float DamageRateAdd { get { return damageRateAdd; } }

    public float CoolTime { get { return coolTime; } }
}