using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    // 작성자 : 김두현
    [SerializeField] string skillName; // 스킬 이름
    [SerializeField][Multiline(3)] string skillInfo; // 스킬 설명
    [SerializeField] Sprite skillImage; // 스킬 이미지

    [SerializeField] int skillLevel; // 스킬 현재 레벨
    [SerializeField] int skillMaxLevel; // 스킬 최대 레벨
    [SerializeField] int skillNeedLevel; // 스킬 습득에 필요한 레벨
    [SerializeField] int skillPoint; // 스킬 습득 혹은 레벨업에 필요한 스킬 포인트

    [SerializeField] SKILL_TYPE skillType;

    public enum SKILL_TYPE { ACTIVE,PASSIVE,PUBLIC}

    public int SkillType { get { return (int)skillType; } }

    public string SkillName { get { return skillName; } }
    public string SkillInfo { get { return skillInfo; } }
    public Sprite SkillImage { get { return skillImage; } }

    public int SkillLevel { get { return skillLevel; } }
    public int SkillMaxLevel { get { return skillMaxLevel; } } 
    public int SkillNeedLevel { get { return skillNeedLevel; } }
    public int SkillPoint { get { return skillPoint; } }

    public void SkillLevelUp()
    {
        skillLevel++;
    }

    public void SkillLevelUpAll()
    {
        while(true)
        {
            /* if(Player.instance.StatPoint>=skillPoint)
             * {
             *      
             * }
             */
        }
    }
}