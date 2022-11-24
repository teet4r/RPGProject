using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInfo : MonoBehaviour
{
    // �ۼ��� : �����
    /* itemSlot - itemImage
     */
    const float updateTime = 0.05f;

    PointerEventData pointer = new PointerEventData(EventSystem.current);
    List<RaycastResult> raycastResults = new List<RaycastResult>();
    [SerializeField] GameObject equipmentItemInfoWindow, consumableItemInfoWindow, normalItemInfoWindow;
    [SerializeField] GameObject skillInfoWindow;
    RectTransform itemInfoWindowRect;
    RectTransform skillInfoWindowRect;
    EquipmentItemInfoWindow equipmentItemInfoWindowCpnt;
    ConsumableItemInfoWindow consumableItemInfoWindowCpnt;
    NormalItemInfoWindow normalItemInfoWindowCpnt;
    bool windowOn = false;
    float time = 0f;
    private void Start()
    {
        equipmentItemInfoWindowCpnt = equipmentItemInfoWindow.GetComponent<EquipmentItemInfoWindow>();
        consumableItemInfoWindowCpnt = consumableItemInfoWindow.GetComponent<ConsumableItemInfoWindow>();
        normalItemInfoWindowCpnt = normalItemInfoWindow.GetComponent<NormalItemInfoWindow>();
        skillInfoWindowRect = skillInfoWindow.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if(time>=updateTime)
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 1)
            {
                if (raycastResults[1].gameObject.GetComponent<ItemSlot>() && raycastResults[1].gameObject.GetComponent<ItemSlot>().Item != null)
                {
                    if (windowOn)
                    {
                        return;
                    }
                    EnableItemInfoWindow(raycastResults[1].gameObject.GetComponent<ItemSlot>());
                    itemInfoWindowRect.position = Input.mousePosition;
                }
                else
                {
                    DisableItemInfoWindow();
                }
                if (raycastResults[1].gameObject.GetComponent<SkillSlot>() && raycastResults[1].gameObject.GetComponent<SkillSlot>().Skill != null)
                {
                    if (windowOn)
                    {
                        return;
                    }
                }
                else
                {
                }
            }
            else
            {
                DisableItemInfoWindow();
                skillInfoWindow.SetActive(false);
            }
            raycastResults.Clear();
            time = 0f;
        }
        time += Time.deltaTime;
    }

    void EnableItemInfoWindow(ItemSlot _itemSlot)
    {
        windowOn = true;
        switch ((int)_itemSlot.Item.ItemType)
        {
            case (int)Item.ITEM_TYPE.EQUIPMENT:
                itemInfoWindowRect = equipmentItemInfoWindow.GetComponent<RectTransform>();
                equipmentItemInfoWindow.SetActive(true);
                equipmentItemInfoWindow.GetComponent<EquipmentItemInfoWindow>().SetItemInfoWindow(_itemSlot);
                break;
            case (int)Item.ITEM_TYPE.CONSUMABLE:
                itemInfoWindowRect = consumableItemInfoWindow.GetComponent<RectTransform>();
                consumableItemInfoWindow.SetActive(true);
                consumableItemInfoWindow.GetComponent<ConsumableItemInfoWindow>().SetItemInfoWindow(_itemSlot);
                break;
            case (int)Item.ITEM_TYPE.OTHER:
            case (int)Item.ITEM_TYPE.QUEST:
                itemInfoWindowRect = normalItemInfoWindow.GetComponent<RectTransform>();
                normalItemInfoWindow.SetActive(true);
                break;
        }
    }
    void DisableItemInfoWindow()
    {
        windowOn = false;
        equipmentItemInfoWindow.SetActive(false);
        consumableItemInfoWindow.SetActive(false);
        normalItemInfoWindow.SetActive(false);
    }
}