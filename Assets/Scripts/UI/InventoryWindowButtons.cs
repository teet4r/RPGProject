using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryWindowButtons : MonoBehaviour
{
    // �ۼ��� : �����
    [SerializeField] GameObject itemTabGroup;

    public void SelectItemTabOpenButton()
    {
        for (int i = 0; i < itemTabGroup.transform.childCount; i++)
        {
            itemTabGroup.transform.GetChild(i).gameObject.SetActive(false);
        }
        itemTabGroup.transform.GetChild(int.Parse(EventSystem.current.currentSelectedGameObject.name.Split('_')[1])).gameObject.SetActive(true);
    }
    public void SelectInventoryAlignButton()
    {
        // 20221102 �����
        // ���� �����ִ� �κ��丮 �Ǹ� ����
        // ���� ���� ������ ����� ������ ����
    }
}