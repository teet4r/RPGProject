using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumableSlot : MonoBehaviour
{
    ConsumableItem item;
    Image itemImage;
    Image itemNumImage;
    Text itemNumText;

    public void SetSlotItem(ConsumableItem _item)
    {
        item = _item;
        RefreshSlotNum();
    }

    void RefreshSlotNum()
    {
        Color color = itemNumImage.color;
        color.a = 1f;
        itemNumImage.color = color;
        itemNumText.text = Inventory.instance.HowManyItem(item).ToString();
    }

    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        Color color = itemNumImage.color;
        color.a = 0f;
        itemNumImage.color = color;
        itemNumText.text = "";
    }
}