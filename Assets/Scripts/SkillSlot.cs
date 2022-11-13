using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlot : MonoBehaviour
{
    // �ۼ��� : �����
    [SerializeField] Skill skill;
    [SerializeField] Image skillImage;

    public Skill Skill { get { return skill; } }

    private void Start()
    {
        skillImage.sprite = skill.SkillImage;
    }
}