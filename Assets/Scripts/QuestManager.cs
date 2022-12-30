using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    // 작성자 : 김두현
    public static QuestManager instance;

    [SerializeField] QuestInfo[] questInfos;
    [SerializeField] GameObject questInfoGroup;
    [SerializeField] GameObject questNoneSelectedWindow;
    [SerializeField] Sprite[] questIcons = new Sprite[(int)Quest.QUEST_TYPE.ENUM_SIZE];

    public QuestInfo[] QuestInfos { get { return questInfos; } }
    public Sprite[] QuestIcons { get { return questIcons; } }

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
    }

    public void ActivateQuestInfoGroup(bool _activate)
    {
        questInfoGroup.SetActive(_activate);
        questNoneSelectedWindow.SetActive(!_activate);
    }

    public void SetQuestInfoGroup(int _questCode)
    {
        Text[] questInfoTexts = questInfoGroup.GetComponentsInChildren<Text>();
        Quest _quest = questInfos[_questCode].Quest;
        questInfoTexts[0].text = _quest.QuestTitle;
        questInfoTexts[1].text = _quest.QuestNpc;
        questInfoTexts[2].text = _quest.QuestInfo;
        questInfoTexts[3].text = _quest.QuestRequireItem.Item.ItemName + ' '; // 수정
        questInfoTexts[5].text = "경험치 : " + _quest.QuestPrizeExp.ToString();
        questInfoTexts[6].text = "골드 : " + _quest.QuestPrizeGold.ToString();
    }

    void RefreshRequireText()
    {
    }

    [System.Serializable]
    public class QuestInfo
    {
        [SerializeField] Quest quest; // 퀘스트
        [SerializeField] bool questStartable = false; // 퀘스트 시작 가능한지 여부 - 선행 퀘스트 완료 하였는지 체크
        [SerializeField] bool questCompletable = false; // 퀘스트 완료 가능 여부
        [SerializeField] bool questComplete = false; // 퀘스트 완료 여부
        [SerializeField] int monsterKill = 0; // 몬스터 처치 수
        [SerializeField] int itemNum = 0; // 아이템 개수

        public Quest Quest { get { return quest; } }
        public bool QuestStartable { get { return questStartable; } }

        public void SetQuestStartable(int _questCode)
        {
            if (quest.QuestCode <= _questCode)
            {
                questStartable = true;
            }
        }

        public void CheckQuestCompletable()
        {
            if (quest.QuestRequireItem.ItemNum <= itemNum)
            {

            }
        }
    }
}