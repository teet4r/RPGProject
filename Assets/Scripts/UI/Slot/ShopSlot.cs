using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] GameObject shopSlotButton;
    [SerializeField] Text itemNameText;
    [SerializeField] Text buyPriceText;
    [SerializeField] ItemSlot itemSlot;

    private void Start()
    {
        buyPriceText.text = itemSlot.Item.BuyPrice.ToString() + " Gold";
        itemNameText.text = itemSlot.Item.ItemName;
    }
}