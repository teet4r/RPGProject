using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUpWindow : MonoBehaviour
{
    ItemSlot itemSlot;
    [SerializeField] Image itemImage;
    [SerializeField] Text itemNameText;
    [SerializeField] Slider itemNumSlider;
    [SerializeField] Text itemNumMinText;
    [SerializeField] Text itemNumMaxText;
    [SerializeField] Text itemPriceText;
    [SerializeField] InputField itemNumInputField;
    int itemPrice;

    private void Start()
    {
        itemNumSlider.onValueChanged.AddListener(delegate { CheckSliderValueChanged(); });
    }

    void CheckSliderValueChanged()
    {
        SetSliderText();
    }

    public void SetBuyPopUp(ItemSlot _itemSlot)
    {
        SetTradePopUp(_itemSlot);
        itemPrice = _itemSlot.Item.BuyPrice;
        SetPopUpText();
    }

    public void SetSellPopUp(ItemSlot _itemSlot)
    {
        SetTradePopUp(_itemSlot);
        itemPrice = _itemSlot.Item.SellPrice;
        SetPopUpText();
    }

    public void SetDropPopUp(ItemSlot _itemSlot)
    {
        SetTradePopUp(_itemSlot);
        itemPrice = _itemSlot.Item.SellPrice;
        SetPopUpText();
    }

    void SetPopUpText()
    {
        itemPriceText.text = $"{itemPrice * itemNumSlider.value} Gold";
        itemNumInputField.text = "";
    }

    void SetTradePopUp(ItemSlot _itemSlot)
    {
        itemSlot = _itemSlot;
        itemImage.sprite = _itemSlot.Item.ItemImage;
        itemNameText.text = _itemSlot.Item.ItemName;
        itemNumSlider.minValue = 0;
        itemNumSlider.maxValue = _itemSlot.Item.BundleSize;
        itemNumMinText.text = $"{itemNumSlider.minValue}";
        itemNumMaxText.text = $"{itemNumSlider.maxValue}";
        itemNumSlider.value = itemNumSlider.minValue;
    }

    void SetSliderText()
    {
        itemNumInputField.text = $"{itemNumSlider.value}";
        itemPriceText.text = $"{itemNumSlider.value * itemPrice} Gold";
    }

    public void SelectItemBuyButton()
    {
        Inventory.instance.BuyItem(itemSlot.Item, (int)itemNumSlider.value);
        gameObject.SetActive(false);
    }

    public void SelectItemSellButton()
    {
        Inventory.instance.SellItem(itemSlot.Item, (int)itemNumSlider.value);
        gameObject.SetActive(false);
    }

    public void SelectItemDropButton()
    {
        Inventory.instance.DeleteItem(itemSlot.Item, (int)itemNumSlider.value);
        gameObject.SetActive(false);
    }
}