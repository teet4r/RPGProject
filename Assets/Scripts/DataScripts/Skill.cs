using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill/Skill")]
public class Skill : ScriptableObject
{
    // �ۼ��� : �����
    [SerializeField] string skillName; // ��ų �̸�
    [SerializeField] Sprite skillImage; // ��ų �̹���

    [SerializeField] int skillMana; // ��ų ��뿡 �ʿ��� ����

    [SerializeField] float coolTime; // ��ų ���� ���ð�

    [SerializeField] string skillInfo; // ��ų ����

    public string SkillName { get { return skillName; } }
    public Sprite SkillImage { get { return skillImage; } }

    public int SkillMana { get { return skillMana; } }

    public float CoolTime { get { return coolTime; } }

    public string SkillInfo { get { return skillInfo; } }
}