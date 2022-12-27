using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Quest",menuName ="Quest/Quest")]
public class Quest : ScriptableObject
{
    // �ۼ��� : �����
    [SerializeField] string questTitle; // ����Ʈ ����
    [SerializeField] string questNpc; // ����Ʈ Npc
    [SerializeField] string questInfo; // ����Ʈ ����
    [SerializeField] string questRequire; // ����Ʈ �Ϸ� ����

    [SerializeField] int questCode; // ����Ʈ

    [SerializeField] QuestPrizeItem[] questPrizeItems; // ����Ʈ ���� ������ ����Ʈ
    [SerializeField] int questPrizeGold; // ����Ʈ ���� ���
    [SerializeField] int questPrizeExp; // ����Ʈ ���� ����ġ
}

[System.Serializable]
public class QuestPrizeItem
{
    [SerializeField] Item item;
    [SerializeField] int itemNum;
}