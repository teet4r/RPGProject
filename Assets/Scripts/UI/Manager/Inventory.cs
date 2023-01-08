using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    [SerializeField] Text goldText;
    [SerializeField] int gold = 0;

    public int Gold { get { return gold; } }
    public GameObject ItemSlots { get { return itemSlots; } }

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

    private void Update()
    {
        if (goldText.gameObject.activeSelf)
        {
            goldText.text = $"{gold} Gold";
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

    public void UseItem(ConsumableItem _item)
    {
        if (HowManyItem(_item) > 0)
        {
            switch(_item.ConsumableType)
            {
                case ConsumableItem.CONSUMABLE_TYPE.HP_POTION:
                    if (!ItemManager.instance.ConsumableItemUsable[0])
                    {
                        AlertManager.instance.ShowAlert("아직 사용할 수 없습니다.");
                        return;
                    }
                    Player.instance.AddHp(_item.HpRecoverNum);
                    ItemManager.instance.SetConsumableItemUsableFalse(0);
                    break;
                case ConsumableItem.CONSUMABLE_TYPE.MP_POTION:
                    if (!ItemManager.instance.ConsumableItemUsable[1])
                    {
                        AlertManager.instance.ShowAlert("아직 사용할 수 없습니다.");
                        return;
                    }
                    Player.instance.AddMp(_item.MpRecoverNum);
                    ItemManager.instance.SetConsumableItemUsableFalse(1);
                    break;
            }
            DeleteItem(_item);
        }
        else
        {
            AlertManager.instance.ShowAlert($"{_item.ItemName} 의 개수가 부족합니다.");
        }
    }

    public void BuyItem(Item _item, int _num)
    {
        if (HowManyItemCanBuy(_item) < _num)
        {
            AlertManager.instance.ShowAlert("인벤토리가 부족합니다.");
            return;
        }

        if (_item.BuyPrice * _num > gold)
        {
            AlertManager.instance.ShowAlert("골드가 부족합니다.");
            return;
        }

        AddGold(-1 * _item.BuyPrice * _num);
        AcquireItem(_item, _num);
    }

    public void SellItem(Item _item, int _num)
    {
        if (HowManyItemCanSell(_item) < _num)
        {
            AlertManager.instance.ShowAlert("아이템이 부족합니다.");
            return;
        }

        AddGold(_item.SellPrice * _num);
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
                    tmp = 0;
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
                if (_item.BundleSize < tmp)
                {
                    tmpSlot.SetItem(_item, _item.BundleSize);
                    tmp -= _item.BundleSize;
                }
                else
                {
                    tmpSlot.SetItem(_item, tmp);
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
            AlertManager.instance.ShowAlert("골드가 부족합니다.");
        }
        else
        {
            gold += _gold;
        }
    }

    public void RefreshItemCoolTimeImage(ConsumableItem.CONSUMABLE_TYPE _consumableItemType)
    {
        for (int i = 0; i < itemSlots.transform.childCount; i++)
        {
            ItemSlot tmpSlot = itemSlots.transform.GetChild(i).GetComponent<ItemSlot>();
            if (tmpSlot.ConsumableItem == null) continue;
            if (tmpSlot.ConsumableItem.ConsumableType == _consumableItemType)
            {
                try
                {
                    if (!ItemManager.instance.ConsumableItemUsable[(int)_consumableItemType])
                    {
                        tmpSlot.SetCoolTimeImage(ItemManager.instance.ConsumableItemCoolTime[(int)_consumableItemType] / ItemManager.instance.ConsumableItemCoolTimeMax);
                    }
                    else
                    {
                        tmpSlot.SetCoolTimeImage(0f);
                    }
                }
                catch { }
            }
        }
    }
}