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
    [SerializeField] GameObject holdingItemImage;
    [SerializeField] GameObject droppingItemWindow;
    [SerializeField] GameObject sellingItemWindow;
    bool isHoldingItem = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0)
            {
                try
                {
                    if (raycastResults[1].gameObject.GetComponent<ItemSlot>())
                    {
                        selectedItem = raycastResults[1].gameObject.GetComponent<ItemSlot>();
                        if (selectedItem.GetComponent<ItemSlot>().Item != null)
                        {
                            holdingItemImage.SetActive(true);
                            isHoldingItem = true;
                        }
                    }
                }
                catch { }
                raycastResults.Clear();
            }
        }
        if (Input.GetMouseButton(0) && isHoldingItem)
        {
            holdingItemImage.GetComponent<Image>().sprite = selectedItem.GetComponent<Image>().sprite;
            holdingItemImage.GetComponent<RectTransform>().transform.position = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && isHoldingItem)
        {
            holdingItemImage.SetActive(false);
            isHoldingItem = false;
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0)
            {
                try
                {
                    if (raycastResults[1].gameObject.GetComponent<ItemSlot>() && raycastResults[1].gameObject.CompareTag("ItemSlot"))
                    {
                        raycastResults[1].gameObject.GetComponent<ItemSlot>().SetItem(selectedItem.Item);
                        raycastResults[1].gameObject.GetComponent<ItemSlot>().SetItemNum(selectedItem.ItemNum);
                    }
                    else if (raycastResults[1].gameObject.CompareTag("Shop") || raycastResults[0].gameObject.CompareTag("Shop"))
                    {
                        sellingItemWindow.SetActive(true);
                    }
                    else if (raycastResults[1].gameObject.GetComponent<ItemSlot>() && raycastResults[1].gameObject.CompareTag("PotionSlot") && selectedItem.Item.ItemType == Item.ITEM_TYPE.CONSUMABLE) // Æ÷¼Ç Äü½½·Ô
                    {
                        raycastResults[1].gameObject.GetComponent<PotionSlot>().SetSlotItem(selectedItem.ConsumableItem);
                    }
                }
                catch { }
                raycastResults.Clear();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0)
            {
                GameObject tmpObject = raycastResults[1].gameObject;
                if (tmpObject.GetComponent<ItemSlot>() && tmpObject.CompareTag("ItemSlot"))
                {
                    if (tmpObject.GetComponent<ItemSlot>().Item.ItemType == Item.ITEM_TYPE.CONSUMABLE)
                    {
                        ////////////////////
                    }
                }
            }
        }
    }
}