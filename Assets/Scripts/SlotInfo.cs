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
    private void Start()
    {
        itemInfoWindowRect = itemInfoWindow.GetComponent<RectTransform>();
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
                itemInfoWindowRect.position = Input.mousePosition - new Vector3(itemInfoWindowRect.sizeDelta.x / 2, itemInfoWindowRect.sizeDelta.y / 2, 0);
            }
            if (raycastResults[1].gameObject.GetComponent<SkillSlot>() && raycastResults[1].gameObject.GetComponent<SkillSlot>().Skill != null)
            {
                if(skillInfoWindow.activeSelf)
                {
                    return;
                }
                skillInfoWindow.SetActive(true);
                skillInfoWindowRect.position = Input.mousePosition - new Vector3(skillInfoWindowRect.sizeDelta.x / 2, skillInfoWindowRect.sizeDelta.y / 2, 0);
            }
        }
        else
        {
            itemInfoWindow.SetActive(false);
        }
        raycastResults.Clear();
    }
}