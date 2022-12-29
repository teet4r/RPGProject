using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
    EquipmentItem equipmentItem;
    [SerializeField] SLOT_TYPE slotType;

    public SLOT_TYPE SlotType { get { return slotType; } }

    public enum SLOT_TYPE { SWORD, AXE, SHIELD }

    public void AddStatToPlayer()
    {
        /* Player.instance.AddStat(Player.STAT_TYPE.DMG, equipmentItem.Damage);
         * Player.instance.AddStat(Player.STAT_TYPE.DEF, equipmentItem.Defense);
         */
    }

    public void ClearSlot()
    {

    }
}