using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    // 작성자 : 김두현
    /* 아이템 습득, 아이템 개수 등에 관련한 내용이 들어갈 예정
     * HowManyItem(Item _item) return int - 인벤토리에 _item 개수 반환
     * HowManyItemCanSell(Item _item) return int - 인벤토리에 _item 개수를 검사하여 해당 _item.BundleSize 보다 개수가 많을 경우 _item.BundleSize 반환 그 외의 경우 _item 개수 반환
     *      판매 불가능한 상품을 인자로 받았을 경우 -1 을 고정으로 반환
     * HowManyItemCanBuy(Item _item) return int - 인벤토리에 빈 슬롯, _item 이 들어있는 슬롯을 모두 검사하여 _item.BundleSize 보다 개수가 많을 경우 _item.BundleSize 반환
     *      그 외의 경우 _item 을 구매 가능한 최대 개수 반환
     */

    public static Inventory instance;

    [SerializeField] GameObject itemSlots;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public int HowManyItem(Item _item)
    {
        int num = 0;
        for (int i = 0; i < itemSlots.transform.childCount; i++)
        {
            if (itemSlots.transform.GetChild(i).GetComponent<ItemSlot>().Item == _item)
            {
                num += itemSlots.transform.GetChild(i).GetComponent<ItemSlot>().ItemNum;
            }
        }
        return num;
    }

    public int HowManyItemCanSell(Item _item)
    {
        if (!_item.CanSell) return -1;
        int num = 0;
        for (int i = 0; i < itemSlots.transform.childCount; i++)
        {
            if (itemSlots.transform.GetChild(i).GetComponent<ItemSlot>().Item == _item)
            {
                num += itemSlots.transform.GetChild(i).GetComponent<ItemSlot>().ItemNum;
            }
        }
        if (num > _item.BundleSize)
        {
            return _item.BundleSize;
        }
        else
        {
            return num;
        }
    }

    public int HowManyItemCanBuy(Item _item)
    {
        int num = 0;
        for (int i = 0; i < itemSlots.transform.childCount; i++)
        {
            if (itemSlots.transform.GetChild(i).GetComponent<ItemSlot>().Item == null)
            {
                num += _item.BundleSize;
            }
            else if (itemSlots.transform.GetChild(i).GetComponent<ItemSlot>().Item == _item)
            {
                num += _item.BundleSize - itemSlots.transform.GetChild(i).GetComponent<ItemSlot>().ItemNum;
            }
        }
        if (num > _item.BundleSize)
        {
            return _item.BundleSize;
        }
        else
        {
            return num;
        }
    }

    public void UseItem(Item _item)
    {
        if (HowManyItem(_item) > 0)
        {
        }
        else
        {
            AlertManager.instance.ShowAlert($"{_item.ItemName} 의 개수가 부족합니다.");
        }
    }

    public void BuyItem(Item _item, int _num)
    {
        if (HowManyItemCanBuy(_item) >= _num)
        {
            AlertManager.instance.ShowAlert("인벤토리가 부족합니다.");
            return;
        }
        /*
        if (_item.BuyPrice * _num < )
        {
            AlertManager.instance.ShowAlert("골드가 부족합니다.");
            return;
        }
        */
        AcquireItem(_item, _num);
    }

    public void SellItem(Item _item, int _num)
    {
        if (HowManyItemCanSell(_item) < _num)
        {
            AlertManager.instance.ShowAlert("아이템이 부족합니다.");
            return;
        }
        DeleteItem(_item, _num);
    }

    public void DeleteItem(Item _item, int _num)
    {
        int tmp = _num;
        ItemSlot tmpSlot;
        for (int i = 0; i < itemSlots.transform.childCount; i++)
        {
            tmpSlot = itemSlots.transform.GetChild(i).GetComponent<ItemSlot>();
            if (tmpSlot.Item == _item && tmpSlot.ItemNum > 0)
            {

            }
        }
    }

    public void AcquireItem(Item _item, int _num)
    {
        int tmp = _num;
        ItemSlot tmpSlot;
        for (int i = 0; i < itemSlots.transform.childCount; i++)
        {
            tmpSlot = itemSlots.transform.GetChild(i).GetComponent<ItemSlot>();
            if (tmpSlot.Item == _item && tmpSlot.ItemNum < _item.BundleSize)
            {
            }
        }
    }
}