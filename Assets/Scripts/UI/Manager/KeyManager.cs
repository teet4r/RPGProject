using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    // 작성자 : 김두현
    // input.GetKeyDown(KeyManager.instance.Key(KeyManager.KEYNAME.SAMPLE))
    public static KeyManager instance;

    // 캐릭터 이동
    public enum KEYNAME
    {
        // 캐릭터 이동
        MOVE_UP, MOVE_DOWN, MOVE_LEFT, MOVE_RIGHT,
        // 캐릭터 조작
        CHAR_ATTACK, CHAR_RUN, CHAR_DODGE,
        // 일반 조작
        NORM_INTERACTION, NORM_DEFENSE, NORM_CLOSE, NORM_INVENTORY, NORM_CHARACTERINFO, NORM_QUEST,
        // 퀵슬롯
        QUICK_POTION_1, QUICK_POTION_2, QUICK_SKILL_1, QUICK_SKILL2
    }
    KeyCode[] defaultKeys = new KeyCode[]
    {
        // 캐릭터 이동
        KeyCode.W, KeyCode.S, KeyCode.A,KeyCode.D,
        // 캐릭터 조작
        KeyCode.Mouse0, KeyCode.LeftShift, KeyCode.LeftControl,
        // 일반 조작
        KeyCode.F, KeyCode.Mouse1, KeyCode.Escape, KeyCode.I, KeyCode.P, KeyCode.J,
        // 퀵슬롯
        KeyCode.Q, KeyCode.E, KeyCode.Alpha1, KeyCode.Alpha2
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
    }

    private void Start()
    {
        for (int i = 0; i < defaultKeys.Length; i++)
        {
            keys.Add((KEYNAME)i, defaultKeys[i]);
        }
        tmpKeys = defaultKeys;
        SetKeyText();
        ResetAllKey();
    }

    void SetKeyText() // SAVE
    {
        for (int i = 0; i < keys.Count; i++)
        {
            //keySettingWindow.transform.GetChild(i).GetComponentInChildren<Text>().text = keys[(KEYNAME)i].ToString();
        }
    }

    public void ResetAllKey() //초기화
    {
        SoundManager.instance.sfxPlayer.Play(Sfx.ButtonCancel);
        for (int i = 0; i < keys.Count; i++)
        {
            tmpKeys[i] = defaultKeys[i];
        }
    }

    public void SaveKeySet()
    {
        SoundManager.instance.sfxPlayer.Play(Sfx.ButtonConfirm);
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
        SoundManager.instance.sfxPlayer.Play(Sfx.ButtonCancel);
        for (int i = 0; i < keys.Count; i++)
        {
            keySettingWindow.transform.GetChild(i).GetComponentInChildren<Text>().text = tmpKeys[i].ToString();
        }
    }
}