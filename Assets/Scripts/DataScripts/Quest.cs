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

    [SerializeField] int questCode; // 퀘스트

    [SerializeField] QuestPrizeItem[] questPrizeItems; // 퀘스트 보상 아이템 리스트
    [SerializeField] int questPrizeGold; // 퀘스트 보상 골드
    [SerializeField] int questPrizeExp; // 퀘스트 보상 경험치
}

[System.Serializable]
public class QuestPrizeItem
{
    [SerializeField] Item item;
    [SerializeField] int itemNum;
}