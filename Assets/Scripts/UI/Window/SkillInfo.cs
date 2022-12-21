using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfo : MonoBehaviour
{
    // 작성자 : 김두현
    [SerializeField] Text skillName; // 스킬 이름
    [SerializeField] Text skillLevel; // 현재 스킬 레벨
    [SerializeField] Text skillNeedLevel; // 습득 or 레벨 업에 필요한 플레이어 레벨

    Skill skill;

    private void Start()
    {
        skill = GetComponentInChildren<SkillSlot>().Skill;
        skillName.text = skill.SkillName;
        skillLevel.text = /* SkillManager.instance.SkillLevels[idx].ToString() + '/' + */ skill.SkillMaxLevel.ToString();
        // SkillManager 작성 필요 20221113 20:18
        skillNeedLevel.text = skill.SkillNeedLevel.ToString();
    }
}