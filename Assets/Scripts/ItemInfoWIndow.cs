using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoWindow : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] Text itemName;
    [SerializeField] Text itemHowMany;
    [SerializeField] GameObject itemStatInfoTexts;
    [SerializeField] Text itemLevelLimit;
    [SerializeField] Text itemCanReinforce;
    [SerializeField] Text itemInfo;

    public void SetItemInfoWindow(ItemSlot _itemSlot)
    {
        itemImage.sprite = _itemSlot.Item.ItemImage;
        if (_itemSlot.ReinforceLevel > 0)
        {
            itemName.text = "(" + _itemSlot.ReinforceLevel.ToString() + ") ";
        }
        itemName.text += _itemSlot.Item.ItemName;
        itemHowMany.text = "보유 수량 : " + _itemSlot.ItemNum.ToString();
        DisableStatInfoTexts();
        EnableStatInfoTexts(_itemSlot.Item);
    }

    void DisableStatInfoTexts()
    {
        for (int i = itemStatInfoTexts.transform.childCount; i > 0; i++)
        {
            itemStatInfoTexts.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void EnableStatInfoTexts(Item _item)
    {
        if(_item.GetComponent<EquipmentItem>())
        {
            Debug.Log("HI");
        }
    }
}