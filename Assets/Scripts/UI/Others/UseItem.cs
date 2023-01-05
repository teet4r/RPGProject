using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UseItem : MonoBehaviour
{
    PointerEventData pointer = new PointerEventData(EventSystem.current);
    List<RaycastResult> raycastResults = new List<RaycastResult>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count == 0) return;
            GameObject _itemSlot = raycastResults[0].gameObject.transform.parent.gameObject;
            if (_itemSlot.GetComponent<ItemSlot>() && _itemSlot.GetComponent<ItemSlot>().Item.ItemType == Item.ITEM_TYPE.CONSUMABLE)
            {
                Inventory.instance.UseItem(_itemSlot.GetComponent<ItemSlot>().ConsumableItem);
            }
            raycastResults.Clear();
        }
    }
}