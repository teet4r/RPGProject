using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItemInfoWindow : MonoBehaviour
{
    // �ۼ��� : �����
    const int normalHeight = 110; // ������ ����â �⺻ ����
    const int infoHeight = 28; // ������ ���� ���� ����
    const int addHeight = 8; // ������ ����â ���� ����
    const int statNum = 8; // ������ ����â ���� �ִ� ����
    const int otherTextGroupNormalYPos = -336; // ������ ����â �߰����� �⺻ y�� ��ġ

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
        itemLevelRequire.text = "���� ���� LV" + _itemSlot.EquipmentItem.LevelRequire.ToString();
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
        SetItemInfoWindowHeight(tmp);
    }

    void SetItemInfoWindowHeight(int _num)
    {
        // �������� ��ȭ���ɿ��� �������� ����
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, normalHeight + infoHeight * (_num + 2) + addHeight);
        itemOtherInfoTexts.GetComponent<RectTransform>().localPosition = new Vector2(itemOtherInfoTexts.GetComponent<RectTransform>().localPosition.x, otherTextGroupNormalYPos + infoHeight * (statNum - _num));
    }
}