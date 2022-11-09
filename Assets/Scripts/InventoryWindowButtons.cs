using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryWindowButtons : MonoBehaviour
{
    // 작성자 : 김두현
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
        // 20221102 김두현
        // 현재 열려있는 인벤토리 탭만 정렬
        // 이후 정렬 기준이 생기면 구현할 예정
    }
}