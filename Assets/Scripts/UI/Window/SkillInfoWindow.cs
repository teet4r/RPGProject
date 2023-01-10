using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoWindow : MonoBehaviour
{
    [SerializeField] Image skillImage;
    [SerializeField] Text skillName;
    [SerializeField] Text skillMana;
    [SerializeField] Text skillCoolTime;
    [SerializeField] Text skillInfo;

    public void SetSkillInfoWindow(SkillSlot _skillSlot)
    {
        ClearWindow();
        skillImage.sprite = _skillSlot.Skill.SkillImage;
        skillName.text = _skillSlot.Skill.SkillName;
        skillMana.text = $"마나 소모 {_skillSlot.Skill.SkillMana}";
        skillCoolTime.text = $"쿨타임 {_skillSlot.Skill.CoolTime}초";
        skillInfo.text = $"{_skillSlot.Skill.SkillInfo}";
    }

    void ClearWindow()
    {
        skillImage.sprite = null;
        skillName.text = skillMana.text = skillCoolTime.text = skillInfo.text = "";
    }
}