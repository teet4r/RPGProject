using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // �ۼ��� : �����
    Item item;

    [SerializeField] EquipmentItem equipmentItem;
    [SerializeField] ConsumableItem consumableItem;
    [SerializeField] OtherItem otherItem;
    [SerializeField] SLOT_TYPE slotType;
    [SerializeField] int itemNum;
    [SerializeField] Image itemNumImage;
    Image itemImage;
    Text itemNumText;

    public enum SLOT_TYPE { INVENTORY, EQUIPMENT, NORMAL }
    // INVENTORY - �κ��丮 ����
    // EQUIPMENT - ���â ����
    // NORMAL - ���� ������ ���� EX) ����Ʈ ���� �����۽���, ���� �����۽��� ��
    
    public Item Item { get { return item; } }
    public int ItemNum { get { return itemNum; } }

    public EquipmentItem EquipmentItem { get { return equipmentItem; } }
    public ConsumableItem ConsumableItem { get { return consumableItem; } }
    public OtherItem OtherItem { get { return otherItem; } }

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
        equipmentItem = null;
        consumableItem = null;
        otherItem = null;
    }

    public void SetItem<T>(T _item) where T : Item
    {
        T tmp = _item;
        item = tmp;
    }

    void InitItem()
    {
        if (equipmentItem != null)
            item = equipmentItem;
        else if (consumableItem != null)
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