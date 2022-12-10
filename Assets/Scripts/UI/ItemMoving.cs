using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemMoving : MonoBehaviour
{
    PointerEventData pointer = new PointerEventData(EventSystem.current);
    List<RaycastResult> raycastResults = new List<RaycastResult>();
    ItemSlot selectedItem;
    ItemSlot unselectedItem;
    SkillSlot selectedSkill;
    //QuickSlot unselectedSlot;
    [SerializeField] GameObject holdingItemImage;
    [SerializeField] GameObject holdingSkillImage;
    [SerializeField] GameObject droppingItemWindow;
    [SerializeField] GameObject sellingItemWindow;
    bool isHoldingItem = false;
    bool isHoldingSkill = false;

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
                    }else if (raycastResults[1].gameObject.GetComponent<SkillSlot>())
                    {
                        selectedSkill = raycastResults[1].gameObject.GetComponent<SkillSlot>();
                        if(selectedSkill.GetComponent<SkillSlot>().Skill != null)
                        {
                            holdingSkillImage.SetActive(true);
                            isHoldingSkill = true;
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
        if (Input.GetMouseButton(0) && isHoldingSkill)
        {
            holdingSkillImage.GetComponent<Image>().sprite = selectedSkill.GetComponent<Image>().sprite;
            holdingSkillImage.GetComponent<RectTransform>().transform.position = Input.mousePosition;
        }

        /* 슬롯별로 구분이 필요
         * 인벤토리 슬롯(구분없음) 장비창 슬롯(부위별 구분)
         * 상점 슬롯(아이템 스왑불가) 퀵 슬롯(소비 아이템 구분)
         * 
         * 인벤토리 슬롯 -> 장비창 슬롯 / 슬롯 타입이 같으면 스왑 가능
         * 인벤토리 슬롯 -> 상점 슬롯 / 슬롯 타입에 관계없이 아이템 판매팝업 작동
         * 인벤토리 슬롯 -> 퀵 슬롯 / 소비 아이템인 경우만 덮어씌우기
         * 장비창 슬롯 -> 인벤토리 슬롯 / 슬롯 타입이 같으면 스왑 가능
         * 장비창 슬롯 -> 상점 슬롯 / 슬롯 타입에 관계없이 아이템 판매팝업 작동
         * 장비창 슬롯 -> 퀵 슬롯 / 작동 불가
         * 상점 슬롯 - 아이템 픽업 작동 불가
         * 퀵 슬롯 - 아이템 픽업 작동 불가
         */

        if (Input.GetMouseButtonUp(0) && isHoldingItem)
        {
            holdingItemImage.SetActive(false);
            isHoldingItem = false;
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0)
            {
                // 아이템 슬롯 관련 구현
                if (raycastResults[1].gameObject.GetComponent<ItemSlot>())
                {

                }
            }
        }
        if (Input.GetMouseButtonUp(0) && isHoldingSkill)
        {
            holdingSkillImage.SetActive(false);
            isHoldingSkill = false;
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0)
            {
                // 스킬 슬롯 관련 구현
                if (raycastResults[1].gameObject.GetComponent<SkillSlot>())
                {

                }
            }
        }
    }
}