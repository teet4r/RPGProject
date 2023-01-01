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
    [SerializeField] GameObject questWindow;
    [SerializeField] GameObject uiGroup;

    Dictionary<int, KeyCode> keySettings = new Dictionary<int, KeyCode>();

    public enum UI_TYPE { INVENTORY, CHARACTERINFO, SKILL, QUEST }

    private void Start()
    {
        keySettings.Add((int)UI_TYPE.INVENTORY, KeyCode.I);
        keySettings.Add((int)UI_TYPE.CHARACTERINFO, KeyCode.P);
        keySettings.Add((int)UI_TYPE.QUEST, KeyCode.Q);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CheckOpenUI()) CloseUI();
            else SelectOptionUI();
        }
        if (Input.GetKeyDown(keySettings[(int)UI_TYPE.INVENTORY])) SelectInventoryUI();
        if (Input.GetKeyDown(keySettings[(int)UI_TYPE.CHARACTERINFO])) SelectCharacterInfoUI();
        if (Input.GetKeyDown(keySettings[(int)UI_TYPE.QUEST])) SelectQuestUI();
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

    bool CheckOpenUI()
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