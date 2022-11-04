using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ConsumableItem",menuName ="Item/Consumable")]
public class ConsumableItem : Item
{
    // 작성자 : 김두현
    [SerializeField] int hpRecoverNum;
    
    [SerializeField] bool isBuff;
    [SerializeField] bool deleteDebuff;
    
    [SerializeField] int damage;
    [SerializeField] int defense;
    [SerializeField] float moveSpeed;
    

    public int HpRecoverNum { get { return hpRecoverNum; } }

    public bool IsBuff { get { return isBuff; } }
    public bool DeleteDebuff { get { return deleteDebuff; } }

    public int Damage { get { return damage; } }
    public int Defense { get { return defense; } }
    public float MoveSpeed { get { return moveSpeed; } }
}