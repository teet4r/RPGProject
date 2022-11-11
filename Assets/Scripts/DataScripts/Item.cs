using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    // 작성자 : 김두현
    [SerializeField] string itemName;
    [SerializeField][Multiline(3)] string itemInfo;

    [SerializeField] Sprite itemImage;

    [SerializeField] int buyPrice;
    [SerializeField] int sellPrice;

    [SerializeField] int bundleSize;

    [SerializeField] bool canSell;

    [SerializeField] ITEM_TYPE itemType;

    public enum ITEM_TYPE { EQUIPMENT, CONSUMABLE, OTHER, QUEST}

    public int ItemType { get { return (int)itemType; } }

    public string ItemName { get { return itemName; } }
    public string ItemInfo { get { return itemInfo; } }

    public Sprite ItemImage { get { return itemImage; } }

    public int BuyPrice { get { return buyPrice; } }
    public int SellPrice { get { return sellPrice; } }

    public int BundleSize { get { return bundleSize; } }

    public bool CanSell { get { return canSell; } }
}