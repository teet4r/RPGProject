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
        skillMana.text = _skillSlot.Skill.SkillMana.ToString();
        skillCoolTime.text = _skillSlot.Skill.CoolTime.ToString() + '√ ';
    }

    void ClearWindow()
    {
        skillImage.sprite = null;
        skillName.text = skillMana.text = skillCoolTime.text = skillInfo.text = "";
    }
}