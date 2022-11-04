using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActiveSkill", menuName = "Skill/Active")]
public class ActiveSkill : Skill
{
    // �ۼ��� : �����
    [SerializeField] float damageRate; // 0 ���� ���� ��ų ������
    [SerializeField] float damageRateAdd; // ��ų �������� �����ϴ� ������

    [SerializeField] float defenseRate; // �����ϴ� �����

    [SerializeField] float coolTime; // ��ų ���� ���ð�

    public float DamageRate { get { return damageRate; } }
    public float DamageRateAdd { get { return damageRateAdd; } }

    public float DefenseRate { get { return defenseRate; } }

    public float CoolTime { get { return coolTime; } }
}