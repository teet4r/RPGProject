using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    // 작성자 : 김두현
    /* 20221124 18:50
     * 마지막에 열은 UI가 ESC를 눌렀을 때 가장 먼저 닫히도록 설계하여 개발할 것
     * *** 옵션에서 키세팅 변경이 생길 수 있기에 딕셔너리로 키세팅 구현하였음 ***
     */
    [SerializeField] GameObject inventoryWindow;
    [SerializeField] GameObject characterInfoWindow;
    [SerializeField] GameObject skillWindow;
    [SerializeField] GameObject questWindow;

    Dictionary<int, KeyCode> keySettings = new Dictionary<int, KeyCode>();

    public enum UI_TYPE { INVENTORY, CHARACTERINFO, SKILL, QUEST }

    private void Start()
    {
        for (int i = 0; i < arr.Length; i++) arr[i] = i;
        keySettings.Add((int)UI_TYPE.INVENTORY, KeyCode.I);
        keySettings.Add((int)UI_TYPE.CHARACTERINFO, KeyCode.P);
        keySettings.Add((int)UI_TYPE.SKILL, KeyCode.K);
        keySettings.Add((int)UI_TYPE.QUEST, KeyCode.Q);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) CloseUI();
        if (Input.GetKeyDown(keySettings[(int)UI_TYPE.INVENTORY])) SelectInventoryUI();
        if (Input.GetKeyDown(keySettings[(int)UI_TYPE.CHARACTERINFO])) SelectCharacterInfoUI();
        if (Input.GetKeyDown(keySettings[(int)UI_TYPE.SKILL])) SelectSkillUI();
        if (Input.GetKeyDown(keySettings[(int)UI_TYPE.QUEST])) SelectQuestUI();
    }
    public void SelectInventoryUI()
    {
        inventoryWindow.SetActive(!inventoryWindow.activeSelf);
    }
    public void SelectCharacterInfoUI()
    {
        characterInfoWindow.SetActive(!characterInfoWindow.activeSelf);
    }

    public void SelectSkillUI()
    {
        skillWindow.SetActive(!skillWindow.activeSelf);
    }

    public void SelectQuestUI()
    {
        questWindow.SetActive(!questWindow.activeSelf);
    }

    void CloseUI()
    {

    }
}