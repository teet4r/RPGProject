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
    [SerializeField] Image itemImage;
    [SerializeField] Text itemNumText;
    [SerializeField] Image slotCoolTimeImage;

    public enum SLOT_TYPE { INVENTORY, POTION, NORMAL }
    // INVENTORY - 인벤토리 슬롯
    // POTION - 포션 퀵슬롯
    // NORMAL - 고정 아이템 슬롯 EX) 퀘스트 보상 아이템슬롯, 상점 아이템슬롯 등

    public Item Item { get { return item; } }
    public int ItemNum { get { return itemNum; } }
    public ConsumableItem ConsumableItem { get { return consumableItem; } }
    public OtherItem OtherItem { get { return otherItem; } }
    public Image SlotCoolTimeImage { get { return slotCoolTimeImage; } }

    public SLOT_TYPE SlotType { get { return slotType; } }

    private void Start()
    {
        InitItem();
    }

    void SetItemImage()
    {
        itemImage.sprite = item.ItemImage;
        if (itemNum <= 0) itemImage.color = Color.clear;
        else if (itemNum >= 1) itemImage.color = Color.white;
    }

    public void AddItemNum(int _num)
    {
        itemNum += _num;
        CheckItemNum();
    }

    public void SetItemNum(int _num)
    {
        itemNum = _num;
        CheckItemNum();
    }

    public void SetCoolTimeImage(float _fillAmount)
    {
        slotCoolTimeImage.fillAmount = _fillAmount;
    }

    void CheckItemNum()
    {
        if (itemNum <= 0)
        {
            ClearItemSlot();
        }
        else if (ItemNum == 1)
        {
            itemNumText.gameObject.SetActive(false);
            itemNumImage.gameObject.SetActive(false);
        }
        else if (ItemNum > 1)
        {
            itemNumText.gameObject.SetActive(true);
            itemNumText.text = itemNum.ToString();
            itemNumImage.gameObject.SetActive(true);
        }
    }

    public void ClearItemSlot()
    {
        item = null;
        consumableItem = null;
        otherItem = null;
        itemNum = 0;
        itemNumText.text = "";
        itemNumText.gameObject.SetActive(false);
        itemNumImage.gameObject.SetActive(false);
        itemImage.color = Color.clear;
    }

    void SetItem(Item _item)
    {
        item = _item;
        if (_item.ItemType == Item.ITEM_TYPE.CONSUMABLE)
            consumableItem = ItemManager.instance.ItemContainer.ItemList.GetItem(_item).ConsumableItem;
        if (_item.ItemType == Item.ITEM_TYPE.OTHER)
            otherItem = ItemManager.instance.ItemContainer.ItemList.GetItem(_item).OtherItem;
    }

    public void SetItem(Item _item, int _num)
    {
        SetItem(_item);
        SetItemNum(_num);
        CheckItemNum();
        SetItemImage();
    }

    void InitItem()
    {
        if (item != null)
        {
            switch (item.ItemType)
            {
                case Item.ITEM_TYPE.CONSUMABLE:
                    consumableItem = ItemManager.instance.ItemContainer.ItemList.GetItem(item).ConsumableItem;
                    break;
                case Item.ITEM_TYPE.OTHER:
                    otherItem = ItemManager.instance.ItemContainer.ItemList.GetItem(item).OtherItem;
                    break;
            }
            CheckItemNum();
            SetItemImage();
        }
        else
        {
            ClearItemSlot();
        }
    }
}