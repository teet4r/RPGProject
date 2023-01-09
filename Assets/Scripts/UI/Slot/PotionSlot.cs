using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionSlot : MonoBehaviour
{
    [SerializeField] KeyCode keyCode;
    ConsumableItem item;
    Image itemImage;
    Text itemNumText;

    public void SetKeyCode(KeyCode _keycode)
    {
        keyCode = _keycode;
    }

    public void UseSlot()
    {
        GetComponent<SlotCoolTime>().TriggerSlot();
    }

    public void SetSlotItem(ConsumableItem _item)
    {
        item = _item;
        RefreshSlotNum();
    }

    void RefreshSlotNum()
    {
        itemNumText.text = Inventory.instance.HowManyItem(item).ToString();
    }

    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        itemNumText.text = "";
    }
}