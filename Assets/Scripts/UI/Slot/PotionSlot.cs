using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionSlot : MonoBehaviour
{
    [SerializeField] KeyCode keyCode;
    [SerializeField] ConsumableItem item;
    [SerializeField] Image itemImage;
    [SerializeField] Image coolTimeImage;
    [SerializeField] Text itemNumText;

    public ConsumableItem Item { get { return item; } }

    private void Start()
    {
        ClearSlot();
        StartCoroutine(RefreshItemCoolTimeInfo());
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            UseSlot();
        }
    }

    IEnumerator RefreshItemCoolTimeInfo()
    {
        while (true)
        {
            if (item != null && !ItemManager.instance.ConsumableItemUsable[(int)item.ConsumableType])
            {
                SetCoolTimeImage(ItemManager.instance.ConsumableItemCoolTime[(int)item.ConsumableType] / ItemManager.instance.ConsumableItemCoolTimeMax);
            }
            else
            {
                coolTimeImage.gameObject.SetActive(false);
            }
            RefreshSlotNum();
            CheckSlotItemNum();
            yield return new WaitForSeconds(ItemManager.instance.CheckTime);
        }
    }

    void CheckSlotItemNum()
    {
        if (Inventory.instance.HowManyItem(item) <= 0)
        {
            ClearSlot();
        }
    }

    void SetCoolTimeImage(float _fillAmount)
    {
        coolTimeImage.gameObject.SetActive(true);
        coolTimeImage.fillAmount = _fillAmount;
    }

    public void SetKeyCode(KeyCode _keycode)
    {
        keyCode = _keycode;
    }

    public void UseSlot()
    {
        if (item == null) return;
        Inventory.instance.UseItem(item);
        RefreshSlotNum();
    }

    public void SetSlotItem(ConsumableItem _item)
    {
        item = _item;
        itemImage.sprite = _item.ItemImage;
        itemImage.color = Color.white;
        itemNumText.gameObject.SetActive(true);
        RefreshSlotNum();
    }

    void RefreshSlotNum()
    {
        if (itemNumText.gameObject.activeSelf)
            itemNumText.text = $"{Inventory.instance.HowManyItem(item)}";
    }

    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        itemImage.color = Color.clear;
        itemNumText.gameObject.SetActive(false);
    }
}