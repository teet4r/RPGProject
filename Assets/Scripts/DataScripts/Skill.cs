using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    // �ۼ��� : �����
    [SerializeField] string skillName; // ��ų �̸�
    [SerializeField][Multiline(3)] string skillInfo; // ��ų ����
    [SerializeField] Sprite skillImage; // ��ų �̹���

    [SerializeField] int skillMaxLevel; // ��ų �ִ� ����
    [SerializeField] int skillNeedLevel; // ��ų ���濡 �ʿ��� ����
    [SerializeField] int skillPoint; // ��ų ���� Ȥ�� �������� �ʿ��� ��ų ����Ʈ

    [SerializeField] SKILL_TYPE skillType;

    public enum SKILL_TYPE { ACTIVE,PASSIVE,PUBLIC}

    public int SkillType { get { return (int)skillType; } }

    public string SkillName { get { return skillName; } }
    public string SkillInfo { get { return skillInfo; } }
    public Sprite SkillImage { get { return skillImage; } }


    public int SkillMaxLevel { get { return skillMaxLevel; } } 
    public int SkillNeedLevel { get { return skillNeedLevel; } }
    public int SkillPoint { get { return skillPoint; } }
}