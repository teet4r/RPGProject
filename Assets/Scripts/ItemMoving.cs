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
                /* ���Ժ��� ������ �ʿ�
                 * �κ��丮 ����(���о���) ���â ����(������ ����)
                 * ���� ����(������ ���ҺҰ�) �� ����(�Һ� ������ ����)
                 * 
                 * �κ��丮 ���� -> ���â ���� / ���� Ÿ���� ������ ���� ����
                 * �κ��丮 ���� -> ���� ���� / ���� Ÿ�Կ� ������� ������ �Ǹ��˾� �۵�
                 * �κ��丮 ���� -> �� ���� / �Һ� �������� ��츸 ������
                 * ���â ���� -> �κ��丮 ���� / ���� Ÿ���� ������ ���� ����
                 * ���â ���� -> ���� ���� / ���� Ÿ�Կ� ������� ������ �Ǹ��˾� �۵�
                 * ���â ���� -> �� ���� / �۵� �Ұ�
                 * ���� ���� - ������ �Ⱦ� �۵� �Ұ�
                 * �� ���� - ������ �Ⱦ� �۵� �Ұ�
                 */
                try
                {
                    selectedItem = raycastResults[1].gameObject.GetComponent<ItemSlot>();
                    if (selectedItem.GetComponent<ItemSlot>().Item != null)
                    {
                        holdingItemImage.SetActive(true);
                        isHoldingItem = true;
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
        if (Input.GetMouseButtonUp(0) && isHoldingItem)
        {
            holdingItemImage.SetActive(false);
            isHoldingItem = false;
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0)
            {
                /* ���� Ÿ�Ժ� üũ �� ������ ����
                 * 
                 */
            }
        }
    }
}