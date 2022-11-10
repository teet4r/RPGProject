using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // 작성자 : 김두현
    [SerializeField] GameObject inventoryWindow;
    [SerializeField] GameObject characterInfoWindow;
    [SerializeField] GameObject skillWindow;
    [SerializeField] GameObject questWindow;
    private void Update()
    {
        OpenInventoryUI();
        OpenCharacterInfoUI();
        OpenSkillUI();
        OpenQuestUI();
    }
    void OpenInventoryUI()
    {
        if (Input.GetKeyDown(KeyCode.I)) inventoryWindow.SetActive(!inventoryWindow.activeSelf);
    }
    void OpenCharacterInfoUI()
    {
        if (Input.GetKeyDown(KeyCode.P)) characterInfoWindow.SetActive(!characterInfoWindow.activeSelf);
    }

    void OpenSkillUI()
    {
        if (Input.GetKeyDown(KeyCode.K)) skillWindow.SetActive(!skillWindow.activeSelf);
    }

    void OpenQuestUI()
    {
        if (Input.GetKeyDown(KeyCode.Q)) questWindow.SetActive(!questWindow.activeSelf);
    }
}