using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EquipmentItem",menuName ="Item/Equipment")]
public class EquipmentItem : Item
{
    // 작성자 : 김두현
    [SerializeField] int[] stats;

    [SerializeField] int damage;
    [SerializeField] int defense;

    [SerializeField] float moveSpeed;

    [SerializeField] int criticalRate;
    [SerializeField] float criticalDamage;

    [SerializeField] ItemRecipe[] itemRecipes;

    [SerializeField] EQUIPMENT_TYPE equipmentType;

    [SerializeField] int levelRequire;

    [SerializeField] int reinforceLimit;

    public enum EQUIPMENT_TYPE { WEAPON,SHIELD,HELMET,ARMOR,SHOES}

    public int EquipmentType { get { return (int)equipmentType; } }

    public int[] Stats { get { return stats; } } // 0str 1vit 2dex 3luk 4dmg 5def 6mvspd 7crt 8crtdmg

    public int Damage { get { return damage; } }
    public int Defense { get { return defense; } }

    public float MoveSpeed { get { return moveSpeed; } }

    public int CriticalRate { get { return criticalRate; } }
    public float CriticalDamage { get { return criticalDamage; } }

    public ItemRecipe[] ItemRecipes { get { return itemRecipes; } }

    public int LevelRequire { get { return levelRequire; } }

    public int ReinforceLimit { get { return reinforceLimit; } }
}

[System.Serializable]
public class ItemRecipe
{
    [SerializeField] ItemIngredient[] itemIngredients;
}

[System.Serializable]
public class ItemIngredient
{
    [SerializeField] Item item;
    [SerializeField] int itemAmount;
}