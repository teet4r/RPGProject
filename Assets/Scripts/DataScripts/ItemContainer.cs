using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemContainer",menuName ="ItemContainer/ItemContainer")]
public class ItemContainer : ScriptableObject
{
    [SerializeField] ItemList<Item, ItemCon> itemList = new();

    public ItemList<Item,ItemCon> ItemList { get { return itemList; } }

    [System.Serializable]
    public class ItemCon
    {
        [SerializeField] ConsumableItem consumableItem;
        [SerializeField] OtherItem otherItem;

        public ConsumableItem ConsumableItem { get { return consumableItem; } }
        public OtherItem OtherItem { get { return otherItem; } }
    }
}