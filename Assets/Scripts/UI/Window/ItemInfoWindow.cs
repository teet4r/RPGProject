using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoWindow : MonoBehaviour
{
    // �ۼ��� : �����
    [SerializeField] Image itemImage;
    [SerializeField] Text itemName;
    [SerializeField] Text itemNum;
    [SerializeField] Text itemInfo;
    [SerializeField] Text itemSellPrice;

    public void SetItemInfoWindow(Item _item)
    {
        itemImage.sprite = _item.ItemImage;
        itemName.text = _item.ItemName;
        itemNum.text = $"���� ���� : {Inventory.instance.HowManyItem(_item)}";
        itemInfo.text = _item.ItemInfo;
        itemSellPrice.text = $"{_item.SellPrice} Gold";
    }
}