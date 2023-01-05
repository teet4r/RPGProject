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
                if (raycastResults[0].gameObject.transform.parent.GetComponent<ItemSlot>() && raycastResults[0].gameObject.transform.parent.CompareTag("ItemSlot"))
                {
                    selectedItem = raycastResults[0].gameObject.transform.parent.GetComponent<ItemSlot>();
                    if (selectedItem.Item != null)
                    {
                        holdingItemImage.SetActive(true);
                        isHoldingItem = true;
                    }
                }
            }
            raycastResults.Clear();
        }
        if (Input.GetMouseButton(0) && isHoldingItem)
        {
            holdingItemImage.GetComponent<Image>().sprite = selectedItem.Item.ItemImage;
            holdingItemImage.GetComponent<RectTransform>().transform.position = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && isHoldingItem)
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            holdingItemImage.SetActive(false);
            isHoldingItem = false;
            if (raycastResults.Count > 0)
            {
                if (raycastResults[0].gameObject.transform.parent.GetComponent<ItemSlot>() && raycastResults[0].gameObject.transform.parent.CompareTag("ItemSlot"))
                {
                    raycastResults[0].gameObject.transform.parent.GetComponent<ItemSlot>().SetItem(selectedItem.ConsumableItem);
                    raycastResults[0].gameObject.transform.parent.GetComponent<ItemSlot>().SetItem(selectedItem.OtherItem);
                    raycastResults[0].gameObject.transform.parent.GetComponent<ItemSlot>().SetItemNum(selectedItem.ItemNum);
                }
                else if (raycastResults[0].gameObject.transform.parent.CompareTag("ShopSlot") || raycastResults[0].gameObject.transform.parent.CompareTag("ShopSlot"))
                {
                    sellingItemWindow.SetActive(true);
                }
                else if (raycastResults[0].gameObject.transform.parent.GetComponent<PotionSlot>() && raycastResults[0].gameObject.transform.parent.CompareTag("PotionSlot") && selectedItem.Item.ItemType == Item.ITEM_TYPE.CONSUMABLE) // Æ÷¼Ç Äü½½·Ô
                {
                    raycastResults[0].gameObject.transform.parent.GetComponent<PotionSlot>().SetSlotItem(selectedItem.ConsumableItem);
                }
            }
            raycastResults.Clear();
        }
    }
}