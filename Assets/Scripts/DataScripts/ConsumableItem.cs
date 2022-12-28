using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ConsumableItem",menuName ="Item/Consumable")]
public class ConsumableItem : Item
{
    // �ۼ��� : �����
    [SerializeField] int hpRecoverNum;
    [SerializeField] int mpRecoverNum;    

    public int HpRecoverNum { get { return hpRecoverNum; } }
    public int MpRecoverNum { get { return mpRecoverNum; } }
}