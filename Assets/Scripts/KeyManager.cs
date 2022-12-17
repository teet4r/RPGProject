using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    // 작성자 : 김두현
    public const int moveSize = 4;
    public const int characterControlSize = 4;
    public const int normalControlSize = 7;

    public static KeyManager instance;
    [SerializeField] KeySet basicKeySet;
    [SerializeField] KeySet userKeySet;

    // 캐릭터 이동
    public enum MOVE { UP, DOWN, LEFT, RIGHT }
    KeyCode[] moveKeys = new KeyCode[moveSize];
    public KeyCode[] MoveKeys { get { return moveKeys; } }
    // 캐릭터 조작
    public enum CHARACTER_CONTROL { ATTACK, RUN, DASH, JUMP }
    KeyCode[] characterControlKeys = new KeyCode[characterControlSize];
    public KeyCode[] CharacterKeys { get { return characterControlKeys; } }
    // 일반 조작
    public enum NORMAL_CONTROL { INTERACTION, SIGHT_ROTATION, OPTION, INVENTORY, CHARACTER_INFO, SKILL, QUEST }
    KeyCode[] normalControlKeys = new KeyCode[normalControlSize];
    public KeyCode[] NormalKeys { get { return normalControlKeys; } }
    // 퀵슬롯
    KeyCode[] potionSlotsKeys;
    public KeyCode[] PotionKeys { get { return potionSlotsKeys; } }
    KeyCode[] skillSlotsKeys;
    public KeyCode[] SkillKeys { get { return skillSlotsKeys; } }

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

    void ResetAllKey()
    {
        moveKeys = basicKeySet.Move;
        characterControlKeys = basicKeySet.CharacterControl;
        normalControlKeys = basicKeySet.NormalControl;
        potionSlotsKeys = basicKeySet.PotionSlots;
        skillSlotsKeys = basicKeySet.SkillSlots;
    }

    public void SaveKeySet()
    {
        userKeySet.SetKey(moveKeys, characterControlKeys, normalControlKeys, potionSlotsKeys, skillSlotsKeys);
    }

    bool IsDuplicated(KeyCode _keycode) // 중복체크 함수 true - 중복 false - 미중복
    {
        for (int i = 0; i < moveSize; i++)
        {
            if (_keycode == moveKeys[i]) return true;
        }
        for(int i=0;i<characterControlSize;i++)
        {
            if (_keycode == characterControlKeys[i]) return true;
        }
        for (int i = 0; i < normalControlSize; i++)
        {
            if (_keycode == normalControlKeys[i]) return true;
        }
        for(int i=0;i<potionSlotsKeys.Length;i++)
        {
            if (_keycode == potionSlotsKeys[i]) return true;
        }
        for(int i=0;i<skillSlotsKeys.Length;i++)
        {
            if (_keycode == skillSlotsKeys[i]) return true;
        }
        return false;
    }

    public void SelectKeySetButton()
    {
        // 단축키 설정에서 버튼 누르면 실행될 함수
    }
}