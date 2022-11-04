using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EquipmentItem",menuName ="Item/Equipment")]
public class EquipmentItem : Item
{
    // 작성자 : 김두현
    [SerializeField] int statStr;
    [SerializeField] int statVit;
    [SerializeField] int statDex;
    [SerializeField] int statLuk;

    [SerializeField] int damage;
    [SerializeField] int defense;

    [SerializeField] float moveSpeed;

    [SerializeField] int criticalRate;
    [SerializeField] float criticalDamage;

    [SerializeField] ItemRecipe[] itemRecipes;

    public int StatStr { get { return statStr; } }
    public int StatVit { get { return statVit; } }
    public int StatDex { get { return statDex; } }
    public int StatLuk { get { return statLuk; } }

    public int Damage { get { return damage; } }
    public int Defense { get { return defense; } }

    public float MoveSpeed { get { return moveSpeed; } }

    public int CriticalRate { get { return criticalRate; } }
    public float CriticalDamage { get { return criticalDamage; } }

    public ItemRecipe[] ItemRecipes { get { return itemRecipes; } }
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