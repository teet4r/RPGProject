using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveSkill", menuName = "Skill/Passive")]
public class PassiveSkill : Item
{
    // �ۼ��� : �����
    [SerializeField] int damageNum; // 0 ���� ���� �����ϴ� ������
    [SerializeField] int damageNumAdd; // ��ų �������� �����ϴ� ������
    [SerializeField] int defenseNum; // 0 ���� ���� �����ϴ� ����
    [SerializeField] int defenseNumAdd; // ��ų �������� �����ϴ� ����
    
    [SerializeField] int statAll; // 0 ���� ���� �����ϴ� �� ���ȷ�
    [SerializeField] int statAllNum; // ��ų �������� �����ϴ� �� ���ȷ�
    
    [SerializeField] int criticalRate; // 0 ���� ���� �����ϴ� ġ��Ÿ Ȯ�� 1�� 1%
    [SerializeField] int criticalRateAdd; // ��ų �������� �����ϴ� ġ��Ÿ Ȯ��
    [SerializeField] float criticalDamage; // 0 ���� ���� �����ϴ� ġ��Ÿ ������ 0.01�� 1%
    [SerializeField] float criticalDamageAdd; // ��ų �������� �����ϴ� ġ��Ÿ ������

    public int DamageNum { get { return damageNum; } }
    public int DamageNumAdd { get { return damageNumAdd; } }
    public int DefenseNum { get { return defenseNum; } }
    public int DefenseNumAdd { get { return DefenseNumAdd; } }

    public int StatAll { get { return statAll; } }
    public int StatAllAdd { get { return StatAllAdd; } }

    public int CriticalRate { get { return criticalRate; } }
    public int CriticalRateAdd { get { return criticalRateAdd; } }
    public float CriticalDamage { get { return criticalDamage; } }
    public float CriticalDamageAdd { get { return criticalDamageAdd; } }
}