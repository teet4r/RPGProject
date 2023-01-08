using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ConsumableItem",menuName ="Item/Consumable")]
public class ConsumableItem : Item
{
    // 작성자 : 김두현
    [SerializeField] int hpRecoverNum;
    [SerializeField] int mpRecoverNum;
    [SerializeField] CONSUMABLE_TYPE consumableType;

    public enum CONSUMABLE_TYPE { HP_POTION, MP_POTION, ENUM_SIZE }

    public int HpRecoverNum { get { return hpRecoverNum; } }
    public int MpRecoverNum { get { return mpRecoverNum; } }
    public CONSUMABLE_TYPE ConsumableType { get { return consumableType; } }
}