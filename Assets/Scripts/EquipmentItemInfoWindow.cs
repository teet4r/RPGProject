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
        ClearWindow();
    }

    public void SetItemInfoWindow(ItemSlot _itemSlot)
    {
        ClearWindow();
        itemImage.sprite = _itemSlot.Item.ItemImage;
        if (_itemSlot.ReinforceLevel > 0)
        {
            itemName.text = "(" + _itemSlot.ReinforceLevel.ToString() + ") ";
        }
        itemName.text += _itemSlot.Item.ItemName;
        itemLevelRequire.text = "레벨 제한 LV" + _itemSlot.EquipmentItem.LevelRequire.ToString();
        if (_itemSlot.ReinforceLevel >= _itemSlot.EquipmentItem.ReinforceLimit)
        {
            itemCanReinforce.text = "강화 불가";
        }
        else
        {
            itemCanReinforce.text = "강화 가능";
        }
        EnableStatInfoTexts(_itemSlot.EquipmentItem);
    }

    void ClearWindow()
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

    void EnableStatInfoTexts(EquipmentItem _item)
    {
    }

    void SetStatInfoTexts(EquipmentItem _item)
    {
    }
}