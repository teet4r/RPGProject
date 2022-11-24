using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    // �ۼ��� : �����
    /* 20221124 18:50
     * �������� ���� UI�� ESC�� ������ �� ���� ���� �������� �����Ͽ� ������ ��
     * *** �ɼǿ��� Ű���� ������ ���� �� �ֱ⿡ ��ųʸ��� Ű���� �����Ͽ��� ***
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