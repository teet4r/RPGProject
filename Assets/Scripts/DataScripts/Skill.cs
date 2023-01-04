using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill/Skill")]
public class Skill : ScriptableObject
{
    // 작성자 : 김두현
    [SerializeField] string skillName; // 스킬 이름
    [SerializeField] Sprite skillImage; // 스킬 이미지

    [SerializeField] int skillNeedLevel; // 스킬 습득에 필요한 레벨

    [SerializeField] int skillMana; // 스킬 사용에 필요한 마나

    [SerializeField] float damageRate; // 0 레벨 기준 스킬 데미지 - 500% 는 5.0f
    [SerializeField] float damageRateAdd; // 스킬 레벨업시 증가하는 데미지

    [SerializeField] float coolTime; // 스킬 재사용 대기시간

    [SerializeField] int[] maxExp; // 스킬 레벨업에 필요한 경험치

    [SerializeField] string[] skillInfos; // 스킬 설명

    public string SkillName { get { return skillName; } }
    public Sprite SkillImage { get { return skillImage; } }

    public int SkillNeedLevel { get { return skillNeedLevel; } }

    public int SkillMana { get { return skillMana; } }

    public float DamageRate { get { return damageRate; } }
    public float DamageRateAdd { get { return damageRateAdd; } }

    public float CoolTime { get { return coolTime; } }

    public int[] MaxExp { get { return maxExp; } }

    public string[] SkillInfos { get { return skillInfos; } }
}