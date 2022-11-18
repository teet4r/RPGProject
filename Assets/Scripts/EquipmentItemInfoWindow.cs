using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItemInfoWindow : MonoBehaviour
{
    // 작성자 : 김두현
    [SerializeField] Image itemImage;
    [SerializeField] Text itemName;
    [SerializeField] GameObject itemStatInfoTexts;
    [SerializeField] Text itemLevelRequire;
    [SerializeField] Text itemCanReinforce;
    [SerializeField] Text itemInfo;

    private void OnDisable()
    {
        itemImage.sprite = null;
        itemName.text = "";
        for (int i = itemStatInfoTexts.transform.childCount - 1; i >= 0; i--)
        {
            itemStatInfoTexts.transform.GetChild(i).gameObject.SetActive(false);
        }
        itemLevelRequire.text = "";
        itemCanReinforce.text = "";
        itemInfo.text = "";
    }

    public void SetItemInfoWindow(ItemSlot _itemSlot)
    {
        itemImage.sprite = _itemSlot.Item.ItemImage;
        if (_itemSlot.ReinforceLevel > 0)
        {
            itemName.text = "(" + _itemSlot.ReinforceLevel.ToString() + ") ";
        }
        itemName.text += _itemSlot.Item.ItemName;

        if (CheckEquipment(_itemSlot.Item))
        {
            itemLevelRequire.text = "레벨 제한 LV" + _itemSlot.Item.GetComponent<EquipmentItem>().LevelRequire.ToString();
            if (_itemSlot.ReinforceLevel >= _itemSlot.Item.GetComponent<EquipmentItem>().ReinforceLimit)
            {
                itemCanReinforce.text = "강화 불가";
            }
            else
            {
                itemCanReinforce.text = "강화 가능";
            }
        }
        EnableStatInfoTexts(_itemSlot.Item);

    }

    void EnableStatInfoTexts(Item _item)
    {
    }

    void SetStatInfoTexts(Item _item)
    {
    }

    bool CheckEquipment(Item _item)
    {
        if (_item.ItemType == (int)Item.ITEM_TYPE.EQUIPMENT)
            return true;
        else return false;
    }
}