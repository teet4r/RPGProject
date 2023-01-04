using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    // 작성자 : 김두현
    [SerializeField] GameObject inventoryWindow;
    [SerializeField] GameObject characterInfoWindow;
    [SerializeField] GameObject questWindow;
    [SerializeField] GameObject optionWindow;
    [SerializeField] GameObject uiGroup;
    public enum UI_TYPE { INVENTORY, CHARACTERINFO, QUEST }

    private void Start()
    {
        // optionWindow = GameObject.Find("");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CheckUIOpen()) CloseUI();
            else SelectOptionUI();
        }
        if (Input.GetKeyDown(KeyCode.I)) SelectInventoryUI();
        if (Input.GetKeyDown(KeyCode.P)) SelectCharacterInfoUI();
        if (Input.GetKeyDown(KeyCode.J)) SelectQuestUI();
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

    void SelectOptionUI()
    {
        optionWindow.SetActive(!optionWindow.activeSelf);
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