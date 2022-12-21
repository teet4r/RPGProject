using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill/Skill")]
public class Skill : ScriptableObject
{
    // �ۼ��� : �����
    [SerializeField] string skillName; // ��ų �̸�
    [SerializeField] Sprite skillImage; // ��ų �̹���

    [SerializeField] int skillMaxLevel; // ��ų �ִ� ����
    [SerializeField] int skillNeedLevel; // ��ų ���濡 �ʿ��� ����

    [SerializeField] float damageRate; // 0 ���� ���� ��ų ������ - 500% �� 5.0f
    [SerializeField] float damageRateAdd; // ��ų �������� �����ϴ� ������

    [SerializeField] float coolTime; // ��ų ���� ���ð�

    public string SkillName { get { return skillName; } }
    public Sprite SkillImage { get { return skillImage; } }

    public int SkillMaxLevel { get { return skillMaxLevel; } } 
    public int SkillNeedLevel { get { return skillNeedLevel; } }

    public float DamageRate { get { return damageRate; } }
    public float DamageRateAdd { get { return damageRateAdd; } }

    public float CoolTime { get { return coolTime; } }
}