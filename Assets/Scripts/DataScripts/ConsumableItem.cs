using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ConsumableItem",menuName ="Item/Consumable")]
public class ConsumableItem : Item
{
    // 작성자 : 김두현
    [SerializeField] int hpRecoverNum;
    [SerializeField] int mpRecoverNum;    

    public int HpRecoverNum { get { return hpRecoverNum; } }
    public int MpRecoverNum { get { return mpRecoverNum; } }
}