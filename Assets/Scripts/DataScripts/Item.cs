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

    [SerializeField] bool canSell = true;

    [SerializeField] ITEM_TYPE itemType;

    public enum ITEM_TYPE { CONSUMABLE, OTHER }

    public ITEM_TYPE ItemType { get { return itemType; } }

    public string ItemName { get { return itemName; } }
    public string ItemInfo { get { return itemInfo; } }

    public Sprite ItemImage { get { return itemImage; } }

    public int BuyPrice { get { return buyPrice; } }
    public int SellPrice { get { return sellPrice; } }

    public int BundleSize { get { return bundleSize; } }

    public bool CanSell { get { return canSell; } }
}