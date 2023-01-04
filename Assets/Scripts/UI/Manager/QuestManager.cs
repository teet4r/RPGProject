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
    [SerializeField] GameObject questInfoButtonGroup;
    [SerializeField] GameObject questNoneSelectedWindow;
    [SerializeField] Sprite[] questIcons = new Sprite[(int)Quest.QUEST_TYPE.ENUM_SIZE];

    Text[] questInfoTexts;
    Quest _quest;
    QuestInfo _questInfo;

    public QuestInfo[] QuestInfos { get { return questInfos; } }
    public Sprite[] QuestIcons { get { return questIcons; } }

    public enum QUEST_CODE { START }

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

    private void Start()
    {
        questInfoTexts = questInfoGroup.GetComponentsInChildren<Text>();
    }

    public void ActivateQuestInfoGroup(bool _activate)
    {
        questInfoGroup.SetActive(_activate);
        questNoneSelectedWindow.SetActive(!_activate);
    }

    public void SetQuestInfoGroup(int _questCode)
    {
        _quest = questInfos[_questCode].Quest;
        questInfoTexts[0].text = _quest.QuestTitle;
        questInfoTexts[1].text = _quest.QuestNpc;
        questInfoTexts[2].text = _quest.QuestInfo;
        questInfoTexts[3].text = _quest.QuestRequireItem.Item.ItemName + ' ';
        questInfoTexts[5].text = "경험치 : " + _quest.QuestPrizeExp.ToString();
        questInfoTexts[6].text = "골드 : " + _quest.QuestPrizeGold.ToString();
        RefreshRequireText(_questCode);
    }

    void RefreshRequireText(int _questCode)
    {
        _quest = questInfos[_questCode].Quest;
        if (_quest.QuestRequireItem != null)
        {
            questInfoTexts[3].text = $"{_quest.QuestRequireItem.Item.ItemName} {Inventory.instance.HowManyItem(_quest.QuestRequireItem.Item)}/{_quest.QuestRequireItem.ItemNum} 개 수집하기";
        }
    }

    public void CompleteQuest(int _questCode)
    {
        _questInfo = questInfos[_questCode];
    }

    public void StartQuest(int _questCode)
    {
        _questInfo = questInfos[_questCode];
        if (_questInfo.QuestStartable && questInfos.Length < questInfoButtonGroup.transform.childCount)
        {
            AlertManager.instance.ShowAlert($"\"{_questInfo.Quest.QuestTitle}\" 퀘스트를 수락했습니다.");
        }
        else
        {
            AlertManager.instance.ShowAlert("퀘스트를 시작할 수 없습니다.");
        }
    }

    [System.Serializable]
    public class QuestInfo
    {
        [SerializeField] Quest quest; // 퀘스트
        [SerializeField] bool questStartable = false; // 퀘스트 시작 가능한지 여부 - 선행 퀘스트 완료 하였는지 체크
        [SerializeField] bool questContinuing = false; // 퀘스트 진행중인지 여부
        [SerializeField] bool questCompletable = false; // 퀘스트 완료 가능 여부
        [SerializeField] bool questCompleted = false; // 퀘스트 완료 여부
        [SerializeField] int monsterKill = 0; // 몬스터 처치 수

        public Quest Quest { get { return quest; } }
        public bool QuestStartable { get { return questStartable; } }
        public bool QuestContinuing { get { return questContinuing; } }
        public bool QuestCompletable { get { return questCompletable; } }
        public bool QuestCOmpleted { get { return questCompleted; } }

        public void RefreshQuest()
        {
            SetQuestStartable();
        }

        void SetQuestStartable()
        {
            for (int i = 0; i < quest.QuestCode.Length; i++)
            {
                if (QuestManager.instance.questInfos[quest.QuestCode[i]].questCompleted)
                {
                    questStartable = true;
                }
            }
        }

        public void CheckQuestCompletable()
        {
            if (quest.QuestRequireItem.ItemNum <= Inventory.instance.HowManyItem(quest.QuestRequireItem.Item))
            {
                questCompletable = true;
            }
            /*
            if (quest.QuestRequireMonster.MonsterNum <= monsterKill)
            {
                questCompletable = true;
            }
            */
        }

        public void SetQuestCompleted()
        {
            questCompleted = true;
        }
    }
}