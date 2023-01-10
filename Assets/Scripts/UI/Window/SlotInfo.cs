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
    RectTransform screenRect;

    private void Start()
    {
        itemInfoWindowCpnt = itemInfoWindow.GetComponent<ItemInfoWindow>();
        skillInfoWindowRect = skillInfoWindow.GetComponent<RectTransform>();
        screenRect = GetComponent<RectTransform>();
    }
    private void Update()
    {
        pointer.position = Input.mousePosition;
        EventSystem.current.RaycastAll(pointer, raycastResults);
        if (raycastResults.Count > 0)
        {
            if (raycastResults[0].gameObject.GetComponent<ItemSlot>() && raycastResults[0].gameObject.GetComponent<ItemSlot>().Item != null)
            {
                EnableItemInfoWindow(raycastResults[0].gameObject.GetComponent<ItemSlot>().Item);
                bool isOverRight = false;
                bool isOverDown = false;
                Vector3 mousePosition = Input.mousePosition;

                if (screenRect.rect.width - Input.mousePosition.x < itemInfoWindowRect.rect.width) isOverRight = true;
                if (Input.mousePosition.y < itemInfoWindowRect.rect.height) isOverDown = true;

                if (isOverRight) mousePosition -= new Vector3(itemInfoWindowRect.rect.width, 0, 0);
                if (isOverDown) mousePosition += new Vector3(0, itemInfoWindowRect.rect.height, 0);

                itemInfoWindowRect.position = mousePosition;
            }
            else if (raycastResults[0].gameObject.GetComponent<PotionSlot>() && raycastResults[0].gameObject.GetComponent<PotionSlot>().Item != null)
            {
                EnableItemInfoWindow(raycastResults[0].gameObject.GetComponent<PotionSlot>().Item);
                bool isOverRight = false;
                bool isOverDown = false;
                Vector3 mousePosition = Input.mousePosition;

                if (screenRect.rect.width - Input.mousePosition.x < itemInfoWindowRect.rect.width) isOverRight = true;
                if (Input.mousePosition.y < itemInfoWindowRect.rect.height) isOverDown = true;

                if (isOverRight) mousePosition -= new Vector3(itemInfoWindowRect.rect.width, 0, 0);
                if (isOverDown) mousePosition += new Vector3(0, itemInfoWindowRect.rect.height, 0);

                itemInfoWindowRect.position = mousePosition;
            }
            else
            {
                DisableItemInfoWindow();
            }
            if (raycastResults[0].gameObject.GetComponent<SkillSlot>() && raycastResults[0].gameObject.GetComponent<SkillSlot>().Skill != null)
            {
                EnableSkillInfoWindow(raycastResults[0].gameObject.GetComponent<SkillSlot>());
                bool isOverRight = false;
                bool isOverDown = false;
                Vector3 mousePosition = Input.mousePosition;

                if (screenRect.rect.width - Input.mousePosition.x < skillInfoWindowRect.rect.width) isOverRight = true;
                if (Input.mousePosition.y < skillInfoWindowRect.rect.height) isOverDown = true;

                if (isOverRight) mousePosition -= new Vector3(skillInfoWindowRect.rect.width, 0, 0);
                if (isOverDown) mousePosition += new Vector3(0, skillInfoWindowRect.rect.height, 0);

                skillInfoWindowRect.position = mousePosition;
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


    void EnableItemInfoWindow(Item _item)
    {
        itemInfoWindowRect = itemInfoWindow.GetComponent<RectTransform>();
        itemInfoWindow.SetActive(true);
        itemInfoWindow.GetComponent<ItemInfoWindow>().SetItemInfoWindow(_item);
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