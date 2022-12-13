using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoWindow : MonoBehaviour
{
    [SerializeField] Image skillImage;
    [SerializeField] Text skillName;
    [SerializeField] Text skillType;
    [SerializeField] Text skillMana;
    [SerializeField] Text skillLevel;
    [SerializeField] Text skillCoolTime;
    [SerializeField] Text skillInfo;

    public void SetSkillInfoWindow(SkillSlot _skillSlot)
    {
        ClearWindow();
        skillImage.sprite = _skillSlot.Skill.SkillImage;
        skillName.text = _skillSlot.Skill.SkillName;
        switch(_skillSlot.Skill.SkillType)
        {
            case (int)Skill.SKILL_TYPE.ACTIVE:
                skillType.text = "액티브 스킬";
                break;
            case (int)Skill.SKILL_TYPE.PASSIVE:
                skillType.text = "패시브 스킬";
                break;
            case (int)Skill.SKILL_TYPE.PUBLIC:
                skillType.text = "공용 스킬";
                break;
        }
    }

    void ClearWindow()
    {
        skillImage.sprite = null;
        skillName.text = skillType.text = skillMana.text = skillLevel.text = skillLevel.text = skillCoolTime.text = skillInfo.text = "";
    }
}