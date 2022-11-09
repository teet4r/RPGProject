using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveSkill", menuName = "Skill/Passive")]
public class PassiveSkill : Item
{
    // 작성자 : 김두현
    [SerializeField] int damageNum; // 0 레벨 기준 증가하는 데미지
    [SerializeField] int damageNumAdd; // 스킬 레벨업시 증가하는 데미지
    [SerializeField] int defenseNum; // 0 레벨 기준 증가하는 방어력
    [SerializeField] int defenseNumAdd; // 스킬 레벨업시 증가하는 방어력
    
    [SerializeField] int statAll; // 0 레벨 기준 증가하는 각 스탯량
    [SerializeField] int statAllNum; // 스킬 레벨업시 증가하는 각 스탯량
    
    [SerializeField] int criticalRate; // 0 레벨 기준 증가하는 치명타 확률 1당 1%
    [SerializeField] int criticalRateAdd; // 스킬 레벨업시 증가하는 치명타 확률
    [SerializeField] float criticalDamage; // 0 레벨 기준 증가하는 치명타 데미지 0.01당 1%
    [SerializeField] float criticalDamageAdd; // 스킬 레벨업시 증가하는 치명타 데미지

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