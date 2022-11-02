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
        // 20221102 �����
        // ���� �����ִ� �κ��丮 �Ǹ� ����
        // ���� ���� ������ ����� ������ ����
        GameObject openingTabWindow;
        for (int i = 0; i < itemTabWindows.Length; i++)
        {
            if (itemTabWindows[i].activeSelf)
            { openingTabWindow = itemTabWindows[i]; break; }
        }
    }
}