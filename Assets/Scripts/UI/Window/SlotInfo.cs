using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInfo : MonoBehaviour
{
    // 작성자 : 김두현
    /* itemSlot - itemImage
     */
    const float updateTime = 0.05f;

    PointerEventData pointer = new PointerEventData(EventSystem.current);
    List<RaycastResult> raycastResults = new List<RaycastResult>();
    [SerializeField] GameObject consumableItemInfoWindow, normalItemInfoWindow;
    [SerializeField] GameObject skillInfoWindow;
    RectTransform itemInfoWindowRect;
    RectTransform skillInfoWindowRect;
    ConsumableItemInfoWindow consumableItemInfoWindowCpnt;
    NormalItemInfoWindow normalItemInfoWindowCpnt;
    float time = 0f;
    private void Start()
    {
        consumableItemInfoWindowCpnt = consumableItemInfoWindow.GetComponent<ConsumableItemInfoWindow>();
        normalItemInfoWindowCpnt = normalItemInfoWindow.GetComponent<NormalItemInfoWindow>();
        skillInfoWindowRect = skillInfoWindow.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (time >= updateTime)
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 1)
            {
                if (raycastResults[1].gameObject.GetComponent<ItemSlot>() && raycastResults[1].gameObject.GetComponent<ItemSlot>().Item != null)
                {
                    DisableItemInfoWindow();
                    EnableItemInfoWindow(raycastResults[1].gameObject.GetComponent<ItemSlot>());
                    itemInfoWindowRect.position = Input.mousePosition;
                }
                else
                {
                    DisableItemInfoWindow();
                }
                if (raycastResults[1].gameObject.GetComponent<SkillSlot>() && raycastResults[1].gameObject.GetComponent<SkillSlot>().Skill != null)
                {
                    DisableSkillInfoWindow();
                    EnableSkillInfoWindow(raycastResults[1].gameObject.GetComponent<SkillSlot>());
                    skillInfoWindowRect.position = Input.mousePosition;
                }
                else
                {
                    DisableSkillInfoWindow();
                }
            }
            else
            {
                DisableItemInfoWindow();
                DisableSkillInfoWindow();
            }
            raycastResults.Clear();
            time = 0f;
        }
        time += Time.deltaTime;
    }

    void EnableItemInfoWindow(ItemSlot _itemSlot)
    {
        switch ((int)_itemSlot.Item.ItemType)
        {
            case (int)Item.ITEM_TYPE.CONSUMABLE:
                itemInfoWindowRect = consumableItemInfoWindow.GetComponent<RectTransform>();
                consumableItemInfoWindow.SetActive(true);
                consumableItemInfoWindow.GetComponent<ConsumableItemInfoWindow>().SetItemInfoWindow(_itemSlot);
                break;
            case (int)Item.ITEM_TYPE.OTHER:
                itemInfoWindowRect = normalItemInfoWindow.GetComponent<RectTransform>();
                normalItemInfoWindow.SetActive(true);
                break;
        }
    }

    void EnableSkillInfoWindow(SkillSlot _skillSlot)
    {
        skillInfoWindow.SetActive(true);
        skillInfoWindow.GetComponent<SkillInfoWindow>().SetSkillInfoWindow(_skillSlot);
    }

    void DisableItemInfoWindow()
    {
        consumableItemInfoWindow.SetActive(false);
        normalItemInfoWindow.SetActive(false);
    }

    void DisableSkillInfoWindow()
    {
        skillInfoWindow.SetActive(false);
    }
}