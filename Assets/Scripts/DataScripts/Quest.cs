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
    [SerializeField] string questRequire; // 퀘스트 완료 조건

    [SerializeField] QuestItem[] questRequireItems; // 퀘스트 완료 조건 아이템
    [SerializeField] QuestItem[] questPrizeItems; // 퀘스트 보상 아이템 리스트

    [SerializeField] int questCode; // 퀘스트 발동 조건 숫자

    [SerializeField] int questPrizeGold; // 퀘스트 보상 골드
    [SerializeField] int questPrizeExp; // 퀘스트 보상 경험치

    public string QuestTitle { get { return questTitle; } }
    public string QuestNpc { get { return QuestNpc; } }
    public string QuestInfo { get { return questInfo; } }
    public string QuestRequire { get { return questRequire; } }

    public QuestItem[] QuestRequireItems { get { return questRequireItems; } }
    public QuestItem[] QuestPrizeItems { get { return questPrizeItems; } }


    public int QuestCode { get { return questCode; } }

    public int QuestPrizeGold { get { return questPrizeGold; } }
    public int QuestPrizeExp { get { return questPrizeExp; } }

    [System.Serializable]
    public class QuestItem
    {
        [SerializeField] Item item;
        [SerializeField] int itemNum;
    }
}
