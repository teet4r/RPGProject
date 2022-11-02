using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtons : MonoBehaviour
{
    [SerializeField]
    GameObject[] itemTabWindows;

    enum ITEM_TAB_WINDOWS { EQUIPMENT, CONSUMABLE, OTHER, QUEST }
    public void SelectEqiupmentItemTabButton()
    {
        DisableWindows();
        itemTabWindows[(int)ITEM_TAB_WINDOWS.EQUIPMENT].SetActive(true);
    }
    public void SelectConsumableItemTabButton()
    {
        DisableWindows();
        itemTabWindows[(int)ITEM_TAB_WINDOWS.CONSUMABLE].SetActive(true);
    }
    public void SelectOtherItemTabButton()
    {
        DisableWindows();
        itemTabWindows[(int)ITEM_TAB_WINDOWS.OTHER].SetActive(true);
    }
    public void SelectQuestItemTabButton()
    {
        DisableWindows();
        itemTabWindows[(int)ITEM_TAB_WINDOWS.QUEST].SetActive(true);
    }
    public void DisableWindows()
    {
        for (int i = 0; i < itemTabWindows.Length; i++)
        {
            itemTabWindows[i].SetActive(false);
        }
    }
    public void SelectInventoryAlignButton()
    {
        // 20221102 김두현
        // 현재 열려있는 인벤토리 탭만 정렬
        // 이후 정렬 기준이 생기면 구현할 예정
        GameObject openingTabWindow;
        for (int i = 0; i < itemTabWindows.Length; i++)
        {
            if (itemTabWindows[i].activeSelf)
            { openingTabWindow = itemTabWindows[i]; break; }
        }
    }
}