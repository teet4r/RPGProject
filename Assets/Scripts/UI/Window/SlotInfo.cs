using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInfo : MonoBehaviour
{
    // 작성자 : 김두현
    PointerEventData pointer = new PointerEventData(EventSystem.current);
    List<RaycastResult> raycastResults = new List<RaycastResult>();
    [SerializeField] GameObject itemInfoWindow;
    [SerializeField] GameObject skillInfoWindow;
    RectTransform itemInfoWindowRect;
    RectTransform skillInfoWindowRect;
    ItemInfoWindow itemInfoWindowCpnt;

    private void Start()
    {
        itemInfoWindowCpnt = itemInfoWindow.GetComponent<ItemInfoWindow>();
        skillInfoWindowRect = skillInfoWindow.GetComponent<RectTransform>();
    }
    private void Update()
    {
        pointer.position = Input.mousePosition;
        EventSystem.current.RaycastAll(pointer, raycastResults);
        if (raycastResults.Count > 0)
        {
            if (raycastResults[0].gameObject.transform.parent.GetComponent<ItemSlot>() && raycastResults[0].gameObject.transform.parent.GetComponent<ItemSlot>().Item != null)
            {
                EnableItemInfoWindow(raycastResults[0].gameObject.transform.parent.GetComponent<ItemSlot>());
                itemInfoWindowRect.position = Input.mousePosition;
            }
            else
            {
                DisableItemInfoWindow();
            }
            if (raycastResults[0].gameObject.transform.parent.GetComponent<SkillSlot>() && raycastResults[0].gameObject.transform.parent.GetComponent<SkillSlot>().Skill != null)
            {
                EnableSkillInfoWindow(raycastResults[0].gameObject.transform.gameObject.GetComponent<SkillSlot>());
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
    }


    void EnableItemInfoWindow(ItemSlot _itemSlot)
    {
        itemInfoWindowRect = itemInfoWindow.GetComponent<RectTransform>();
        itemInfoWindow.SetActive(true);
        itemInfoWindow.GetComponent<ItemInfoWindow>().SetItemInfoWindow(_itemSlot);
    }

    void EnableSkillInfoWindow(SkillSlot _skillSlot)
    {
        skillInfoWindow.SetActive(true);
        skillInfoWindow.GetComponent<SkillInfoWindow>().SetSkillInfoWindow(_skillSlot);
    }

    void DisableItemInfoWindow()
    {
        itemInfoWindow.SetActive(false);
    }

    void DisableSkillInfoWindow()
    {
        skillInfoWindow.SetActive(false);
    }
}