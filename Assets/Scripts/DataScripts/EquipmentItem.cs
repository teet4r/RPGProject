using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentItem", menuName = "Item/Equipment")]
public class EquipmentItem : Item
{
    // 작성자 : 김두현
    [SerializeField] int damage;
    [SerializeField] int defense;

    [SerializeField] EQUIPMENT_TYPE equipmentType;

    [SerializeField] int levelRequire;

    public enum EQUIPMENT_TYPE { SWORD, AXE, SHIELD }

    public int EquipmentType { get { return (int)equipmentType; } }

    public int Damage { get { return damage; } }
    public int Defense { get { return defense; } }

    public int LevelRequire { get { return levelRequire; } }
}