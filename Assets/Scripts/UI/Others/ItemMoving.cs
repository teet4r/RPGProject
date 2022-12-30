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
                try
                {
                    if (raycastResults[1].gameObject.GetComponent<ItemSlot>() && raycastResults[1].gameObject.CompareTag("ItemSlot"))
                    {
                        raycastResults[1].gameObject.GetComponent<ItemSlot>().SetItem(selectedItem.Item);
                    }
                    else if (raycastResults[1].gameObject.CompareTag("Shop") || raycastResults[0].gameObject.CompareTag("Shop"))
                    {
                        sellingItemWindow.SetActive(true);
                    }
                    else if (raycastResults[1].gameObject.GetComponent<PotionSlot>()) // 기본 인터페이스 포션 슬롯
                    {
                        raycastResults[1].gameObject.GetComponent<PotionSlot>().SetSlotItem(selectedItem.ConsumableItem);
                    }
                }
                catch { }
                raycastResults.Clear();
            }
        }
    }
}