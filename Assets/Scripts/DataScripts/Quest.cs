using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Quest",menuName ="Quest/Quest")]
public class Quest : ScriptableObject
{
    // 작성자 : 김두현
    [SerializeField] string questTitle; // 퀘스트 제목
    [SerializeField] string questNpc; // 퀘스트 Npc
    [SerializeField] string questInfo; // 퀘스트 설명

    // [SerializeField] MonsterData questRequireMonster; // 퀘스트 완료 조건 몬스터
    [SerializeField] QuestItem questRequireItem; // 퀘스트 완료 조건 아이템
    [SerializeField] QuestItem[] questPrizeItems; // 퀘스트 보상 아이템 리스트

    [SerializeField] int questCode; // 퀘스트 발동 조건 숫자

    [SerializeField] int questPrizeGold; // 퀘스트 보상 골드
    [SerializeField] int questPrizeExp; // 퀘스트 보상 경험치

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
