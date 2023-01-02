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

    // [SerializeField] MonsterData questRequireMonster; // ����Ʈ �Ϸ� ���� ����
    [SerializeField] QuestItem questRequireItem; // ����Ʈ �Ϸ� ���� ������
    [SerializeField] QuestItem[] questPrizeItems; // ����Ʈ ���� ������ ����Ʈ

    [SerializeField] int questCode; // ����Ʈ �ߵ� ���� ����

    [SerializeField] int questPrizeGold; // ����Ʈ ���� ���
    [SerializeField] int questPrizeExp; // ����Ʈ ���� ����ġ

    [SerializeField] QUEST_TYPE questType;

    public enum QUEST_TYPE { MAIN, SUB, ENUM_SIZE }

    public string QuestTitle { get { return questTitle; } }
    public string QuestNpc { get { return QuestNpc; } }
    public string QuestInfo { get { return questInfo; } }

    // public Monster QuestRequireMonster { get { return questRequireMonster; } }
    public QuestItem QuestRequireItem { get { return questRequireItem; } }
    public QuestItem[] QuestPrizeItems { get { return questPrizeItems; } }


    public int QuestCode { get { return questCode; } }

    public int QuestPrizeGold { get { return questPrizeGold; } }
    public int QuestPrizeExp { get { return questPrizeExp; } }

    public QUEST_TYPE QuestType { get { return questType; } }

    [System.Serializable]
    public class QuestItem
    {
        [SerializeField] Item item;
        [SerializeField] int itemNum;

        public Item Item { get { return item; } }
        public int ItemNum { get { return itemNum; } }
    }

    [System.Serializable]
    public class QuestMonster
    {
        // [SerializeField] MonsterData monster;
        [SerializeField] int monsterNum;
        public int MonsterNum { get { return monsterNum; } }
    }
}
