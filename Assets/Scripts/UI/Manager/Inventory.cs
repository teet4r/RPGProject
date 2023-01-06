using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    // �ۼ��� : �����
    /* ������ ����, ������ ���� � ������ ������ �� ����
     * HowManyItem(Item _item) return int - �κ��丮�� _item ���� ��ȯ
     * HowManyItemCanSell(Item _item) return int - �κ��丮�� _item ������ �˻��Ͽ� �ش� _item.BundleSize ���� ������ ���� ��� _item.BundleSize ��ȯ �� ���� ��� _item ���� ��ȯ
     *      �Ǹ� �Ұ����� ��ǰ�� ���ڷ� �޾��� ��� -1 �� �������� ��ȯ
     * HowManyItemCanBuy(Item _item) return int - �κ��丮�� �� ����, _item �� ����ִ� ������ ��� �˻��Ͽ� _item.BundleSize ���� ������ ���� ��� _item.BundleSize ��ȯ
     *      �� ���� ��� _item �� ���� ������ �ִ� ���� ��ȯ
     */

    public static Inventory instance;

    [SerializeField] GameObject itemSlots;
    [SerializeField] int gold = 0;

    public int Gold { get { return gold; } }

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

    private void Start()
    {
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

    public void UseItem(ConsumableItem _item)
    {
        if (HowManyItem(_item) > 0)
        {
            DeleteItem(_item);
            Player.instance.AddHp(_item.HpRecoverNum);
            Player.instance.AddMp(_item.MpRecoverNum);
            }
        else
        {
            AlertManager.instance.ShowAlert($"{_item.ItemName} �� ������ �����մϴ�.");
        }
    }

    public void BuyItem(Item _item, int _num)
    {
        if (HowManyItemCanBuy(_item) >= _num)
        {
            AlertManager.instance.ShowAlert("�κ��丮�� �����մϴ�.");
            return;
        }
        if (_item.BuyPrice * _num > gold)
        {
            AlertManager.instance.ShowAlert("��尡 �����մϴ�.");
            return;
        }
        AcquireItem(_item, _num);
    }

    public void SellItem(Item _item, int _num)
    {
        if (HowManyItemCanSell(_item) < _num)
        {
            AlertManager.instance.ShowAlert("�������� �����մϴ�.");
            return;
        }
        DeleteItem(_item, _num);
    }

    public void DeleteItem(Item _item, int _num = 1)
    {
        int tmp = _num;
        ItemSlot tmpSlot;
        for (int i = 0; i < itemSlots.transform.childCount; i++)
        {
            tmpSlot = itemSlots.transform.GetChild(i).GetComponent<ItemSlot>();
            if (tmpSlot.Item == _item && tmpSlot.ItemNum > 0)
            {
                if (tmp >= tmpSlot.ItemNum)
                {
                    tmp -= tmpSlot.ItemNum;
                    tmpSlot.ClearItemSlot();
                }
                else
                {
                    tmpSlot.AddItemNum(-1 * tmp);
                }
            }
            if (tmp <= 0) break;
        }
    }

    public void AcquireItem(Item _item, int _num = 1)
    {
        int tmp = _num;
        ItemSlot tmpSlot;
        for (int i = 0; i < itemSlots.transform.childCount; i++)
        {
            tmpSlot = itemSlots.transform.GetChild(i).GetComponent<ItemSlot>();
            if (tmpSlot.Item == _item && tmpSlot.ItemNum < _item.BundleSize)
            {
                if (tmp > _item.BundleSize - tmpSlot.ItemNum)
                {
                    tmpSlot.SetItemNum(_item.BundleSize);
                    tmp -= (_item.BundleSize - tmpSlot.ItemNum);
                }
                else
                {
                    tmpSlot.AddItemNum(tmp);
                    tmp = 0;
                }
            }
            else if (tmpSlot.Item == null)
            {
                // tmpSlot.SetItem(_item);
                if (_item.BundleSize < tmp)
                {
                    tmpSlot.SetItemNum(_item.BundleSize);
                    tmp -= _item.BundleSize;
                }
                else
                {
                    tmpSlot.SetItemNum(tmp);
                    tmp = 0;
                }
            }
            if (tmp <= 0) break;
        }
    }

    public void AddGold(int _gold)
    {
        if (gold + _gold < 0)
        {
            AlertManager.instance.ShowAlert("��尡 �����մϴ�.");
        }
        else
        {
            gold += _gold;
        }
    }
}