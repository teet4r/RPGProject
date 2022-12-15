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

    // ĳ���� �̵�
    public enum MOVE { UP, DOWN, LEFT, RIGHT }
    KeyCode[] move;
    // ĳ���� ����
    public enum CHARACTER_CONTROL { ATTACK, RUN, DASH, JUMP }
    KeyCode[] characterControl;
    // �Ϲ� ����
    public enum NORMAL_CONTROL { INTERACTION, SIGHT_ROTATION, OPTION, INVENTORY, CHARACTER_INFO, SKILL, QUEST }
    KeyCode[] normalControl;
    // ������
    KeyCode[] potionSlots;
    KeyCode[] skillSlots;

    /* 1. �ٸ� ��ũ��Ʈ���� KeyManager.instance.~ ���� Ű�� �ҷ��� �� �־����
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