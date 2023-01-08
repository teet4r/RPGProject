using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] Text itemNameText;
    [SerializeField] Text buyPriceText;
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] ItemPopUpWindow buyPopUpWindow;

    private void Start()
    {
        buyPriceText.text = $"{itemSlot.Item.BuyPrice} Gold";
        itemNameText.text = itemSlot.Item.ItemName;
    }
    
    public void OpenBuyPopUpWindow()
    {
        buyPopUpWindow.gameObject.SetActive(true);
        buyPopUpWindow.SetBuyPopUp(itemSlot);
    }
}