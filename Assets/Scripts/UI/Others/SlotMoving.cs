using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotMoving : MonoBehaviour
{
    PointerEventData pointer = new PointerEventData(EventSystem.current);
    List<RaycastResult> raycastResults = new List<RaycastResult>();
    ItemSlot selectedItem;
    ItemSlot unselectedItem;
    PotionSlot potionSlot;
    [SerializeField] GameObject holdingItemImage;
    [SerializeField] ItemPopUpWindow droppingItemWindow;
    [SerializeField] ItemPopUpWindow sellingItemWindow;
    bool isHoldingItem = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0)
            {
                if (!raycastResults[0].gameObject.GetComponent<ItemSlot>())
                {
                    raycastResults.Clear();
                    return;
                }
                if (raycastResults[0].gameObject.CompareTag("ItemSlot"))
                {
                    selectedItem = raycastResults[0].gameObject.GetComponent<ItemSlot>();
                    if (selectedItem.Item != null)
                    {
                        holdingItemImage.GetComponent<Image>().sprite = selectedItem.Item.ItemImage;
                        holdingItemImage.GetComponent<RectTransform>().transform.position = Input.mousePosition;
                        holdingItemImage.SetActive(true);
                        isHoldingItem = true;
                    }
                }
            }
            raycastResults.Clear();
        }
        else if (Input.GetMouseButton(0) && isHoldingItem)
        {
            holdingItemImage.GetComponent<RectTransform>().transform.position = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0) && isHoldingItem)
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            holdingItemImage.SetActive(false);
            isHoldingItem = false;
            if (raycastResults.Count > 0)
            {
                if (raycastResults[0].gameObject.GetComponent<ItemSlot>())
                {
                    unselectedItem = raycastResults[0].gameObject.GetComponent<ItemSlot>();
                }
                else if (raycastResults[0].gameObject.GetComponent<PotionSlot>())
                {
                    potionSlot = raycastResults[0].gameObject.GetComponent<PotionSlot>();
                }
                if (unselectedItem.CompareTag("ItemSlot"))
                {
                    Item tmpItem = unselectedItem.Item;
                    int tmpNum = unselectedItem.ItemNum;

                    if (unselectedItem.Item == null)
                    {
                        unselectedItem.SetItem(selectedItem.Item, selectedItem.ItemNum);
                        selectedItem.ClearItemSlot();
                    }
                    else if (unselectedItem.Item != selectedItem.Item)
                    {
                        unselectedItem.SetItem(selectedItem.Item, selectedItem.ItemNum);
                        selectedItem.SetItem(tmpItem, tmpNum);
                    }
                    else if (unselectedItem.Item == selectedItem.Item && unselectedItem != selectedItem)
                    {
                        if (tmpNum + selectedItem.ItemNum > selectedItem.Item.BundleSize)
                        {
                            int num = tmpNum + selectedItem.ItemNum - selectedItem.Item.BundleSize;
                            unselectedItem.SetItemNum(selectedItem.Item.BundleSize);
                            selectedItem.SetItemNum(num);
                        }
                        else if (tmpNum + selectedItem.ItemNum <= selectedItem.Item.BundleSize)
                        {
                            unselectedItem.AddItemNum(selectedItem.ItemNum);
                            selectedItem.ClearItemSlot();
                        }
                    }
                }
                else if (unselectedItem.CompareTag("Shop"))
                {
                    sellingItemWindow.gameObject.SetActive(true);
                    sellingItemWindow.SetSellPopUp(selectedItem);
                }
                else if (potionSlot != null && potionSlot.CompareTag("QuickSlot") && selectedItem.Item.ItemType == Item.ITEM_TYPE.CONSUMABLE)
                {
                    potionSlot.SetSlotItem(selectedItem.ConsumableItem);
                }
            }
            else
            {
                droppingItemWindow.gameObject.SetActive(true);
                droppingItemWindow.SetDropPopUp(selectedItem);
            }
            raycastResults.Clear();
        }
    }
}