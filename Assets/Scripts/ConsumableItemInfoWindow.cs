using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ConsumableItemInfoWindow : MonoBehaviour
{
    // �ۼ��� : �����
    const int normalHeight = 110; // ������ ����â �⺻ ����
    const int infoHeight = 28; // ������ ���� ���� ����
    const int addHeight = 8; // ������ ����â ���� ����
    const int statNum = 7; // ������ ����â ���� �ִ� ����
    const int otherTextGroupNormalYPos = -308; // ������ ����â �߰����� �⺻ y�� ��ġ

    [SerializeField] Inventory inventory;

    [SerializeField] Image itemImage;
    [SerializeField] Text itemName;
    [SerializeField] Text itemNum;
    [SerializeField] GameObject itemStatInfoTexts;
    [SerializeField] Text itemInfo;
    [SerializeField] GameObject itemInfoText;

    public void SetItemInfoWindow(ItemSlot _itemSlot)
    {
        ClearWindow();
        itemImage.sprite = _itemSlot.GetComponent<ItemSlot>().Item.ItemImage;
        itemName.text = _itemSlot.GetComponent<ItemSlot>().Item.ItemName;
        itemNum.text = "���� ���� : " + inventory.HowManyItem(_itemSlot.Item).ToString();
        itemInfo.text = _itemSlot.GetComponent<ItemSlot>().Item.ItemInfo;
        SetStatInfoTexts(_itemSlot.ConsumableItem);
    }

    void ClearWindow()
    {
        itemImage.sprite = null;
        itemName.text = "";
        itemNum.text = "";
        for (int i = itemStatInfoTexts.transform.childCount - 1; i >= 0; i--)
        {
            itemStatInfoTexts.transform.GetChild(i).gameObject.SetActive(false);
        }
        itemInfo.text = "";
    }

    void SetStatInfoTexts(ConsumableItem _item)
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
        if (_item.MoveSpeed > 0)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "MVSPD + " + _item.MoveSpeed.ToString();
            tmp++;
        }
        if (_item.HpRecoverNum > 0)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "HPRECOV + " + _item.HpRecoverNum.ToString();
            tmp++;
        }
        if (_item.DeleteDebuff == true)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "����� ����";
            tmp++;
        }
        if (_item.Revive == true)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "��Ȱ ������";
            tmp++;
        }
        if (_item.Duration > 0)
        {
            itemStatInfoTexts.transform.GetChild(tmp).gameObject.SetActive(true);
            itemStatInfoTexts.transform.GetChild(tmp).GetComponent<Text>().text = "dur : " + _item.Duration.ToString() + "s";
            tmp++;
        }
        SetItemInfoWindowHeight(tmp);
    }

    void SetItemInfoWindowHeight(int _num)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, normalHeight + infoHeight * _num + addHeight);
        itemInfoText.GetComponent<RectTransform>().localPosition = new Vector2(itemInfo.rectTransform.localPosition.x, otherTextGroupNormalYPos + infoHeight * (statNum - _num));
    }
}