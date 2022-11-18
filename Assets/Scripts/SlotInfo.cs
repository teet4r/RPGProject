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
    PointerEventData pointer = new PointerEventData(EventSystem.current);
    List<RaycastResult> raycastResults = new List<RaycastResult>();
    [SerializeField] GameObject itemInfoWindow;
    [SerializeField] GameObject skillInfoWindow;
    RectTransform itemInfoWindowRect;
    RectTransform skillInfoWindowRect;
    EquipmentItemInfoWindow itemInfoWindowCpnt;
    private void Start()
    {
        itemInfoWindowRect = itemInfoWindow.GetComponent<RectTransform>();
        itemInfoWindowCpnt = itemInfoWindow.GetComponent<EquipmentItemInfoWindow>();
        skillInfoWindowRect = skillInfoWindow.GetComponent<RectTransform>();
    }
    private void Update()
    {
        pointer.position = Input.mousePosition;
        EventSystem.current.RaycastAll(pointer, raycastResults);
        if (raycastResults.Count > 1)
        {
            if (raycastResults[1].gameObject.GetComponent<ItemSlot>() && raycastResults[1].gameObject.GetComponent<ItemSlot>().Item != null)
            {
                if (itemInfoWindow.activeSelf)
                {
                    return;
                }
                itemInfoWindow.SetActive(true);
                itemInfoWindowCpnt.SetItemInfoWindow(raycastResults[1].gameObject.GetComponent<ItemSlot>());
                itemInfoWindowRect.position = Input.mousePosition;
            }
            else
            {
                itemInfoWindow.SetActive(false);
            }
            if (raycastResults[1].gameObject.GetComponent<SkillSlot>() && raycastResults[1].gameObject.GetComponent<SkillSlot>().Skill != null)
            {
                if(skillInfoWindow.activeSelf)
                {
                    return;
                }
                skillInfoWindow.SetActive(true);
                skillInfoWindowRect.position = Input.mousePosition;
            }
            else
            {
                skillInfoWindow.SetActive(false);
            }
        }
        else
        {
            itemInfoWindow.SetActive(false);
            skillInfoWindow.SetActive(false);
        }
        raycastResults.Clear();
    }
}