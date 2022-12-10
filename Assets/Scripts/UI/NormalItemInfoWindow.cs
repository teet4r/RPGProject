using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalItemInfoWindow : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] Text itemName;
    [SerializeField] Text itemNum;
    [SerializeField] Text itemInfo;
    public void SetItemInfoWindow(ItemSlot _itemSlot)
    {
        itemImage.sprite = _itemSlot.GetComponent<ItemSlot>().Item.ItemImage;
        itemName.text = _itemSlot.GetComponent<ItemSlot>().Item.ItemName;
        itemNum.text = "보유 수량 : ";
        itemInfo.text = _itemSlot.GetComponent<ItemSlot>().Item.ItemInfo;
    }
}