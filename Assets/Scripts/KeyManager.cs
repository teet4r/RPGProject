using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    // �ۼ��� : �����
    // input.GetKeyDown(KeyManager.instance.Key(KeyManager.KEYNAME.SAMPLE))
    public static KeyManager instance;

    // ĳ���� �̵�
    public enum KEYNAME
    {
        // ĳ���� �̵�
        MOVE_UP, MOVE_DOWN, MOVE_LEFT, MOVE_RIGHT,
        // ĳ���� ����
        CHAR_ATTACK, CHAR_RUN, CHAR_DODGE, CHAR_JUMP,
        // �Ϲ� ����
        NORM_INTERACTION, NORM_FOCUSMODE, NORM_CLOSE, NORM_INVENTORY, NORM_CHARACTERINFO, NORM_SKILL, NORM_QUEST,
        // ������
        QUICK_POTION_1, QUICK_POTION_2, QUICK_SKILL_1, QUICK_SKILL_2, QUICK_SKILL_3, QUICK_SKILL_4
    }
    KeyCode[] defaultKeys = new KeyCode[]
    {
        // ĳ���� �̵�
        KeyCode.W, KeyCode.S, KeyCode.A,KeyCode.D,
        // ĳ���� ����
        KeyCode.Mouse0, KeyCode.LeftShift, KeyCode.LeftControl, KeyCode.Space,
        // �Ϲ� ����
        KeyCode.F, KeyCode.Mouse1, KeyCode.Escape, KeyCode.I, KeyCode.P, KeyCode.K, KeyCode.J,
        // ������
        KeyCode.Q, KeyCode.E, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4
    };
    KeyCode[] tmpKeys;
    Dictionary<KEYNAME, KeyCode> keys = new();
    GameObject selectedButton;
    [SerializeField] GameObject keySettingWindow;

    public KeyCode Key(KEYNAME name)
    {
        return keys[name];
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        ResetAllKey();
    }

    private void Start()
    {
        for (int i = 0; i < defaultKeys.Length; i++)
        {
            keys.Add((KEYNAME)i, defaultKeys[i]);
        }
        tmpKeys = defaultKeys;
        SetKeyText();
    }

    void SetKeyText() // SAVE
    {
        for (int i = 0; i < keys.Count; i++)
        {
            //keySettingWindow.transform.GetChild(i).GetComponentInChildren<Text>().text = keys[(KEYNAME)i].ToString();
        }
    }

    void ResetAllKey()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            tmpKeys[i] = defaultKeys[i];
        }
    }

    public void SaveKeySet()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            keys[(KEYNAME)i] = tmpKeys[i];
        }
    }

    int key = -1;

    public void SelectKeySetButton(int _key)
    {
        selectedButton = EventSystem.current.currentSelectedGameObject;
        key = _key;
    }
    private void OnGUI()
    {
        Event keyEvent = Event.current;
        if (keyEvent.isKey && selectedButton != null)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (selectedButton.transform.GetSiblingIndex() == i) continue;
                if (tmpKeys[i] == keyEvent.keyCode)
                {
                    tmpKeys[i] = KeyCode.None;
                }
            }
            tmpKeys[selectedButton.transform.GetSiblingIndex()] = keyEvent.keyCode;
            key = -1;
            selectedButton = null;
            RefreshButtonText();
        }
    }
    void RefreshButtonText() // NO_SAVE
    {
        for (int i = 0; i < keys.Count; i++)
        {
            keySettingWindow.transform.GetChild(i).GetComponentInChildren<Text>().text = tmpKeys[i].ToString();
        }
    }
}