using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItemInfoWindow : MonoBehaviour
{
    // 작성자 : 김두현
    const int normalHeight = 110; // 아이템 정보창 기본 높이
    const int infoHeight = 28; // 아이템 정보 한줄 높이
    const int addHeight = 8; // 아이템 정보창 구분 높이
    const int statNum = 8; // 아이템 정보창 스탯 최대 개수
    const int otherTextGroupNormalYPos = -336; // 아이템 정보창 추가정보 기본 y축 위치

    [SerializeField] Image itemImage;
    [SerializeField] Text itemName;
    [SerializeField] GameObject itemStatInfoTexts;
    [SerializeField] Text itemLevelRequire;
    [SerializeField] Text itemCanReinforce;
    [SerializeField] Text itemInfo;
    [SerializeField] GameObject itemOtherInfoTexts;

    public void SetItemInfoWindow(ItemSlot _itemSlot)
    {
        ClearWindow();
        itemImage.sprite = _itemSlot.Item.ItemImage;
        if (_itemSlot.ReinforceLevel > 0)
        {
            itemName.text = "(+" + _itemSlot.ReinforceLevel.ToString() + ") ";
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
        SetStatInfoTexts(_itemSlot.EquipmentItem);
        itemInfo.text = _itemSlot.EquipmentItem.ItemInfo;
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

    void SetStatInfoTexts(EquipmentItem _item)
    {
        int tmp = 0;
        if (_item.Damage > 0)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "DMG + " + _item.Damage.ToString();
            tmp++;
        }
        if (_item.Defense > 0)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "DEF + " + _item.Defense.ToString();
            tmp++;
        }
        if (_item.StatStr > 0)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "STR + " + _item.StatStr.ToString();
            tmp++;
        }
        if (_item.StatVit > 0)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "VIT + " + _item.StatVit.ToString();
            tmp++;
        }
        if (_item.StatDex > 0)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "DEX + " + _item.StatDex.ToString();
            tmp++;
        }
        if (_item.StatLuk > 0)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "LUK + " + _item.StatLuk.ToString();
            tmp++;
        }
        if (_item.CriticalRate > 0)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "CRT + " + _item.CriticalRate.ToString();
            tmp++;
        }
        if (_item.CriticalDamage > 0)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "CRTDMG + " + ((int)(_item.CriticalDamage * 100)).ToString() + "%";
            tmp++;
        }
        SetItemInfoWindowHeight(tmp);
    }

    void SetItemInfoWindowHeight(int _num)
    {
        // 스탯정보 강화가능여부 레벨제한 높이
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, normalHeight + infoHeight * (_num + 2) + addHeight);
        itemOtherInfoTexts.GetComponent<RectTransform>().localPosition = new Vector2(itemOtherInfoTexts.GetComponent<RectTransform>().localPosition.x, otherTextGroupNormalYPos + infoHeight * (statNum - _num));
    }
}