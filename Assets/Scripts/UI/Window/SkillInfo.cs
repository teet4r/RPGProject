using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfo : MonoBehaviour
{
    // �ۼ��� : �����
    [SerializeField] Text skillName; // ��ų �̸�
    [SerializeField] Text skillLevel; // ���� ��ų ����
    [SerializeField] Skill skill;

    private void Start()
    {
        skill = GetComponentInChildren<SkillSlot>().Skill;
        skillName.text = skill.SkillName;
        skillLevel.text = /* SkillManager.instance.SkillLevels[idx].ToString() + '/' + */ "";
    }
}