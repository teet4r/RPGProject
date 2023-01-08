using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill/Skill")]
public class Skill : ScriptableObject
{
    // 작성자 : 김두현
    [SerializeField] string skillName; // 스킬 이름
    [SerializeField] Sprite skillImage; // 스킬 이미지

    [SerializeField] int skillMana; // 스킬 사용에 필요한 마나

    [SerializeField] float coolTime; // 스킬 재사용 대기시간

    [SerializeField] string skillInfo; // 스킬 설명

    public string SkillName { get { return skillName; } }
    public Sprite SkillImage { get { return skillImage; } }

    public int SkillMana { get { return skillMana; } }

    public float CoolTime { get { return coolTime; } }

    public string SkillInfo { get { return skillInfo; } }
}