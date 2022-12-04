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

        if (Input.GetMouseButtonUp(0) && isHoldingItem)
        {
            holdingItemImage.SetActive(false);
            isHoldingItem = false;
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0)
            {
                // ������ ���� ���� ����
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
                // ��ų ���� ���� ����
                if (raycastResults[1].gameObject.GetComponent<SkillSlot>())
                {

                }
            }
        }
    }
}