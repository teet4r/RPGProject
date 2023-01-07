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
                    ItemSlot raySlot = raycastResults[0].gameObject.transform.parent.GetComponent<ItemSlot>();

                    Item tmpItem = raySlot.Item;
                    int tmpNum = raySlot.ItemNum;

                    if(raySlot.Item == null)
                    {
                        raySlot.SetItem(selectedItem.Item, selectedItem.ItemNum);
                        selectedItem.ClearItemSlot();
                    }
                    else if (raySlot.Item != selectedItem.Item)
                    {
                        raySlot.SetItem(selectedItem.Item, selectedItem.ItemNum);
                        selectedItem.SetItem(tmpItem, tmpNum);
                    }
                    else if (raySlot.Item == selectedItem.Item)
                    {
                        if (tmpNum + selectedItem.ItemNum > selectedItem.Item.BundleSize)
                        {
                            int num = tmpNum + selectedItem.ItemNum - selectedItem.Item.BundleSize;
                            raySlot.SetItemNum(selectedItem.Item.BundleSize);
                            selectedItem.SetItemNum(num);
                        }
                        else if (tmpNum + selectedItem.ItemNum <= selectedItem.Item.BundleSize)
                        {
                            raySlot.AddItemNum(selectedItem.ItemNum);
                            selectedItem.ClearItemSlot();
                        }
                    }
                }
                else if (raycastResults[0].gameObject.transform.parent.CompareTag("ShopSlot") || raycastResults[0].gameObject.transform.parent.CompareTag("ShopSlot"))
                {
                    sellingItemWindow.SetActive(true);
                }
                else if (raycastResults[0].gameObject.transform.parent.GetComponent<PotionSlot>() && raycastResults[0].gameObject.transform.parent.CompareTag("QuickSlot") && selectedItem.Item.ItemType == Item.ITEM_TYPE.CONSUMABLE) // 포션 퀵슬롯
                {
                    raycastResults[0].gameObject.transform.parent.GetComponent<PotionSlot>().SetSlotItem(selectedItem.ConsumableItem);
                }
            }
            raycastResults.Clear();
        }
    }
}

// 코루틴
// 가비지
// 디자인 패턴
// 유니티 함수 생명 주기
// 최적화
// 렌더링 파이프라인
// 레퍼런스 타입 vs 밸류 타입
// 구조체 vs 클래스
// 박싱 언박싱
// Json에 대한 이해, 써본 경험

// 인터페이스, 제네릭, 추상화 (숙련도 측면에서)
