using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyManager : MonoBehaviour
{
    // 작성자 : 김두현
    public static KeyManager instance;

    // 캐릭터 이동
    public enum KEYNAME
    {
        // 캐릭터 이동
        MOVE_UP, MOVE_DOWN, MOVE_LEFT, MOVE_RIGHT,
        // 캐릭터 조작
        CHAR_ATTACK, CHAR_RUN, CHAR_DODGE, CHAR_JUMP,
        // 일반 조작
        NORM_INTERACTION, NORM_SIGHTROTATION, NORM_CLOSE, NORM_INVENTORY, NORM_CHARACTERINFO, NORM_SKILL, NORM_QUEST,
        // 퀵슬롯
        QUICK_POTION_1, QUICK_POTION_2, QUICK_SKILL_1, QUICK_SKILL_2,
        ENUM_SIZE
    }
    public KeyCode[] defaultKeys = new KeyCode[]
    {
        // 캐릭터 이동
        KeyCode.W, KeyCode.S, KeyCode.A,KeyCode.D,
        // 캐릭터 조작
        KeyCode.Mouse0, KeyCode.LeftShift, KeyCode.LeftControl, KeyCode.Space,
        // 일반 조작
        KeyCode.F, KeyCode.Mouse1, KeyCode.Escape, KeyCode.I, KeyCode.P, KeyCode.K, KeyCode.J,
        // 퀵슬롯
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Z, KeyCode.X
    };

    Dictionary<KEYNAME, KeyCode> keys = new Dictionary<KEYNAME, KeyCode>();
    GameObject selectedButton;
    KeyCode inputKey;
    bool buttonSelected = false;

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
    }

    void ResetAllKey()
    {
    }

    public void SaveKeySet()
    {
    }

    void RefreshKeyText()
    {
    }

    bool IsDuplicated(KeyCode _keycode) // 중복체크 함수 true - 중복 false - 미중복
    {
        if (keys.ContainsValue(_keycode))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SelectKeySetButton()
    {
        buttonSelected = true;
        selectedButton = EventSystem.current.currentSelectedGameObject;
    }

    private void Update()
    {
        if(buttonSelected)
        {
            inputKey = Event.current.keyCode;
            if (IsDuplicated(inputKey))
            {
            }
        }
    }
}