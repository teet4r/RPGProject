using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    // �ۼ��� : �����
    public const int moveSize = 4;
    public const int characterControlSize = 4;
    public const int normalControlSize = 7;

    public static KeyManager instance;
    [SerializeField] KeySet basicKeySet;
    [SerializeField] KeySet userKeySet;

    // ĳ���� �̵�
    public enum MOVE { UP, DOWN, LEFT, RIGHT }
    KeyCode[] moveKeys = new KeyCode[moveSize];
    public KeyCode[] MoveKeys { get { return moveKeys; } }
    // ĳ���� ����
    public enum CHARACTER_CONTROL { ATTACK, RUN, DASH, JUMP }
    KeyCode[] characterControlKeys = new KeyCode[characterControlSize];
    public KeyCode[] CharacterKeys { get { return characterControlKeys; } }
    // �Ϲ� ����
    public enum NORMAL_CONTROL { INTERACTION, SIGHT_ROTATION, OPTION, INVENTORY, CHARACTER_INFO, SKILL, QUEST }
    KeyCode[] normalControlKeys = new KeyCode[normalControlSize];
    public KeyCode[] NormalKeys { get { return normalControlKeys; } }
    // ������
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

    bool IsDuplicated(KeyCode _keycode) // �ߺ�üũ �Լ� true - �ߺ� false - ���ߺ�
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
        // ����Ű �������� ��ư ������ ����� �Լ�
    }
}