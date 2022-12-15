using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public const int moveSize = 4;
    public const int characterControlSize = 4;
    public const int normalControlSize = 7;

    public static KeyManager instance;
    [SerializeField] KeySet basicKeySet;

    // 캐릭터 이동
    public enum MOVE { UP, DOWN, LEFT, RIGHT }
    KeyCode[] move;
    // 캐릭터 조작
    public enum CHARACTER_CONTROL { ATTACK, RUN, DASH, JUMP }
    KeyCode[] characterControl;
    // 일반 조작
    public enum NORMAL_CONTROL { INTERACTION, SIGHT_ROTATION, OPTION, INVENTORY, CHARACTER_INFO, SKILL, QUEST }
    KeyCode[] normalControl;
    // 퀵슬롯
    KeyCode[] potionSlots;
    KeyCode[] skillSlots;

    /* 1. 다른 스크립트에서 KeyManager.instance.~ 으로 키를 불러올 수 있어야함
     * 
     */
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
        for (int i = 0; i < moveSize; i++)
        {
        }
        for (int i = 0; i < characterControlSize; i++)
        {
        }
        for (int i = 0; i < normalControlSize; i++)
        {
        }
        for (int i = 0; i < potionSlots.Length; i++)
        {
        }
        for (int i = 0; i < skillSlots.Length; i++)
        {
        }
    }
}