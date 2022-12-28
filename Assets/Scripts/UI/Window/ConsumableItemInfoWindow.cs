using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ConsumableItemInfoWindow : MonoBehaviour
{
    // 작성자 : 김두현
    const int normalHeight = 110; // 아이템 정보창 기본 높이
    const int infoHeight = 28; // 아이템 정보 한줄 높이
    const int addHeight = 8; // 아이템 정보창 구분 높이
    const int statNum = 7; // 아이템 정보창 스탯 최대 개수
    const int otherTextGroupNormalYPos = -308; // 아이템 정보창 추가정보 기본 y축 위치

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
        itemNum.text = "보유 수량 : " + inventory.HowManyItem(_itemSlot.Item).ToString();
        itemInfo.text = _itemSlot.GetComponent<ItemSlot>().Item.ItemInfo;
    }

    void ClearWindow()
    {
        itemImage.sprite = null;
        itemName.text = itemNum.text = itemInfo.text = "";
        for (int i = itemStatInfoTexts.transform.childCount - 1; i >= 0; i--)
        {
            itemStatInfoTexts.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void SetItemInfoWindowHeight(int _num)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, normalHeight + infoHeight * _num + addHeight);
        itemInfoText.GetComponent<RectTransform>().localPosition = new Vector2(itemInfo.rectTransform.localPosition.x, otherTextGroupNormalYPos + infoHeight * (statNum - _num));
    }
}