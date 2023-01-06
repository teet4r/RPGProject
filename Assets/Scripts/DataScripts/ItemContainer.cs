using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemContainer",menuName ="ItemContainer/ItemContainer")]
public class ItemContainer : ScriptableObject
{
    [SerializeField] SerializableDictionary<Item, ItemCon> itemList = new();

    public SerializableDictionary<Item,ItemCon> ItemList { get { return itemList; } }

    [System.Serializable]
    public class ItemCon
    {
        [SerializeField] ConsumableItem consumableItem;
        [SerializeField] OtherItem otherItem;

        public ConsumableItem ConsumableItem { get { return consumableItem; } }
        public OtherItem OtherItem { get { return otherItem; } }
    }
}