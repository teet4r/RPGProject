using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // 작성자 : 김두현
    [SerializeField] Item item;
    [SerializeField] ConsumableItem consumableItem;
    [SerializeField] OtherItem otherItem;
    [SerializeField] SLOT_TYPE slotType;
    [SerializeField] int itemNum;
    [SerializeField] Image itemNumImage;
    Image itemImage;
    Text itemNumText;

    public enum SLOT_TYPE { INVENTORY, POTION, NORMAL }
    // INVENTORY - 인벤토리 슬롯
    // POTION - 포션 퀵슬롯
    // NORMAL - 고정 아이템 슬롯 EX) 퀘스트 보상 아이템슬롯, 상점 아이템슬롯 등
    
    public Item Item { get { return item; } }
    public int ItemNum { get { return itemNum; } }
    public ConsumableItem ConsumableItem { get { return consumableItem; } }
    public OtherItem OtherItem { get { return otherItem; } }

    public SLOT_TYPE SlotType { get { return slotType; } }

    private void Start()
    {
        itemImage = GetComponentsInChildren<Image>()[1];
        itemNumImage = GetComponentsInChildren<Image>()[2];
        itemNumText = GetComponentInChildren<Text>();
        InitItem();
        if (item != null)
        {
            SetItemImage();
            SetItemNum(itemNum);
            SetItemImageColor();
        }
        else
        {
            ClearItemSlot();
        }
    }

    public void SetItemImage()
    {
        itemImage.sprite = item.ItemImage;
    }

    public void AddItemNum(int _num)
    {
        if (itemNum + _num <= item.BundleSize)
        {
            itemNum += _num;
        }
        else
        {
            itemNum = item.BundleSize;
        }
    }

    public void SetItemNum(int _num)
    {
        if (itemNum == 0)
        {
            ClearItemSlot();
        }
        else if (itemNum == 1)
        {
            itemNumText.gameObject.SetActive(false);
            itemNumImage.gameObject.SetActive(false);
        }
        else if (itemNum > 1)
        {
            itemNumText.gameObject.SetActive(true);
            itemNumImage.gameObject.SetActive(true);
        }
        itemNum = _num;
        itemNumText.text = itemNum.ToString();
    }

    public void ClearItemSlot()
    {
        item = null;
        itemNum = 0;
        itemNumText.gameObject.SetActive(false);
        itemNumText.text = itemNum.ToString();
        itemNumImage.gameObject.SetActive(false);
        itemImage.color = Color.clear;
        consumableItem = null;
        otherItem = null;
    }

    public void SetItem(ConsumableItem _item)
    {
        consumableItem = _item;
        item = _item;
    }

    public void SetItem(OtherItem _item)
    {
        otherItem = _item;
        item = _item;
    }

    void InitItem()
    {
        if (consumableItem != null)
            item = consumableItem;
        else if (otherItem != null)
            item = otherItem;
    }

    public void SetItemImageColor()
    {
        if (itemNum > 0)
        {
            itemImage.color = Color.white;
        }
        if (itemNum > 1)
        {
            itemNumImage.gameObject.SetActive(true);
        }
    }
}