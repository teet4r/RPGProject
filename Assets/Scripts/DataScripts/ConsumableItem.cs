using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ConsumableItem",menuName ="Item/Consumable")]
public class ConsumableItem : Item
{
    // 작성자 : 김두현
    [SerializeField] int hpRecoverNum;

    [SerializeField] bool revive;
    [SerializeField] bool deleteDebuff;
    [SerializeField] bool isBuff;
    
    [SerializeField] int damage;
    [SerializeField] int defense;
    [SerializeField] float moveSpeed;

    [SerializeField] float duration;
    

    public int HpRecoverNum { get { return hpRecoverNum; } }

    public bool Revive { get { return revive; } }
    public bool DeleteDebuff { get { return deleteDebuff; } }
    public bool IsBuff { get { return isBuff; } }

    public int Damage { get { return damage; } }
    public int Defense { get { return defense; } }
    public float MoveSpeed { get { return moveSpeed; } }

    public float Duration { get { return duration; } }
}