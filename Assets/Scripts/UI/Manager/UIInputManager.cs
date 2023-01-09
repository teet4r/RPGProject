using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    public static UIInputManager instance;
    // �ۼ��� : �����
    [SerializeField] GameObject inventoryWindow;
    [SerializeField] GameObject characterInfoWindow;
    [SerializeField] GameObject questWindow;
    [SerializeField] GameObject uiGroup;
    [SerializeField] GameObject npcShopWindow;
    public enum UI_TYPE { INVENTORY, CHARACTERINFO, QUEST }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CheckUIOpen()) CloseUI();
            else SelectOptionUI();
        }
        if (Input.GetKeyDown(KeyCode.I)) SelectInventoryUI(); ////
        if (Input.GetKeyDown(KeyCode.P)) SelectCharacterInfoUI(); ////
        if (Input.GetKeyDown(KeyCode.J)) SelectQuestUI(); ////
    }
    public void SelectInventoryUI()
    {
        inventoryWindow.SetActive(!inventoryWindow.activeSelf);
        inventoryWindow.transform.SetAsLastSibling();
    }
    public void SelectCharacterInfoUI()
    {
        characterInfoWindow.SetActive(!characterInfoWindow.activeSelf);
        characterInfoWindow.transform.SetAsLastSibling();
    }

    public void SelectQuestUI()
    {
        questWindow.SetActive(!questWindow.activeSelf);
        questWindow.transform.SetAsLastSibling();
    }

    public void SelectNpcShopUI()
    {
        npcShopWindow.SetActive(!npcShopWindow.activeSelf);
    }

    public void SelectOptionUI()
    {
        SettingCanvas.instance.settingBackground.SetActive(!SettingCanvas.instance.settingBackground.activeSelf);
    }

    void CloseUI()
    {
        for (int i = uiGroup.transform.childCount - 1; i >= 0; i--)
        {
            if (!uiGroup.transform.GetChild(i).gameObject.activeSelf)
            {
                continue;
            }
            else
            {
                uiGroup.transform.GetChild(i).gameObject.SetActive(false);
                break;
            }
        }
    }

    public bool CheckUIOpen()
    {
        for (int i = 0; i < uiGroup.transform.childCount; i++)
        {
            if (uiGroup.transform.GetChild(i).gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}