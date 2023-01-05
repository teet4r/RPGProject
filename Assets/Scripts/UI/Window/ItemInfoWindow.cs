using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoWindow : MonoBehaviour
{
    // 작성자 : 김두현
    [SerializeField] Image itemImage;
    [SerializeField] Text itemName;
    [SerializeField] Text itemNum;
    [SerializeField] Text itemInfo;
    [SerializeField] Text itemSellPrice;

    public void SetItemInfoWindow(ItemSlot _itemSlot)
    {
        Item _item = _itemSlot.Item;
        itemImage.sprite = _itemSlot.GetComponent<ItemSlot>().Item.ItemImage;
        itemName.text = _itemSlot.GetComponent<ItemSlot>().Item.ItemName;
        itemNum.text = "보유 수량 : " + Inventory.instance.HowManyItem(_itemSlot.Item).ToString();
        itemInfo.text = _itemSlot.GetComponent<ItemSlot>().Item.ItemInfo;
        itemSellPrice.text = $"{_item.SellPrice} Gold";
    }
}