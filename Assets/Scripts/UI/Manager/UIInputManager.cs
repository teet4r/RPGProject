using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    public static UIInputManager instance;
    // 작성자 : 김두현
    [SerializeField] GameObject inventoryWindow;
    [SerializeField] GameObject characterInfoWindow;
    [SerializeField] GameObject questWindow;
    [SerializeField] GameObject uiGroup;
    [SerializeField] GameObject npcShopWindow;

    public GameObject NpcShopWindow { get { return npcShopWindow; } }
    public GameObject InventoryWindow { get { return inventoryWindow; } }
    public enum UI_TYPE { INVENTORY, CHARACTERINFO, QUEST }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyManager.instance.Key(KeyManager.KEYNAME.NORM_CLOSE)))
        {
            if (CheckUIOpen()) CloseUI();
            else SelectOptionUI();
        }
        if (Input.GetKeyDown(KeyManager.instance.Key(KeyManager.KEYNAME.NORM_INVENTORY))) SelectInventoryUI(); ////
        if (Input.GetKeyDown(KeyManager.instance.Key(KeyManager.KEYNAME.NORM_CHARACTERINFO))) SelectCharacterInfoUI(); ////
        if (Input.GetKeyDown(KeyManager.instance.Key(KeyManager.KEYNAME.NORM_QUEST))) SelectQuestUI(); ////
    }
    public void SelectInventoryUI()
    {
        if (Input.GetKey(KeyCode.Tab) && inventoryWindow.activeSelf)
        {
            inventoryWindow.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            return;
        }
        inventoryWindow.SetActive(!inventoryWindow.activeSelf);
        inventoryWindow.transform.SetAsLastSibling();
    }
    public void SelectCharacterInfoUI()
    {
        if (Input.GetKey(KeyCode.Tab) && characterInfoWindow.activeSelf)
        {
            characterInfoWindow.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            return;
        }
        characterInfoWindow.SetActive(!characterInfoWindow.activeSelf);
        characterInfoWindow.transform.SetAsLastSibling();
    }

    public void SelectQuestUI()
    {
        if (Input.GetKey(KeyCode.Tab) && questWindow.activeSelf)
        {
            questWindow.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            return;
        }
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