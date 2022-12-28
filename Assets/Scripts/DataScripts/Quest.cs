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

    [SerializeField] QuestRequireItem[] questRequireItems; // ����Ʈ �Ϸ� ���� ������
    [SerializeField] QuestPrizeItem[] questPrizeItems; // ����Ʈ ���� ������ ����Ʈ

    [SerializeField] int questCode; // ����Ʈ �ߵ� ���� ����

    [SerializeField] int questPrizeGold; // ����Ʈ ���� ���
    [SerializeField] int questPrizeExp; // ����Ʈ ���� ����ġ

    public string QuestTitle { get { return questTitle; } }
    public string QuestNpc { get { return QuestNpc; } }
    public string QuestInfo { get { return questInfo; } }
    public string QuestRequire { get { return questRequire; } }

    public QuestRequireItem[] QuestRequireItems { get { return questRequireItems; } }
    public QuestPrizeItem[] QuestPrizeItems { get { return questPrizeItems; } }


    public int QuestCode { get { return questCode; } }

    public int QuestPrizeGold { get { return questPrizeGold; } }
    public int QuestPrizeExp { get { return questPrizeExp; } }

    [System.Serializable]
    public class QuestPrizeItem
    {
        [SerializeField] Item item;
        [SerializeField] int itemNum;
    }

    [System.Serializable]
    public class QuestRequireItem
    {
        [SerializeField] Item item;
        [SerializeField] int itemNum;
    }
}
