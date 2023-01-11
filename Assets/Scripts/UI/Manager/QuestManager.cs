using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    // �ۼ��� : �����
    public static QuestManager instance;

    [SerializeField] QuestInfo[] questInfos;
    [SerializeField] GameObject questInfoGroup;
    [SerializeField] GameObject questInfoButtonGroup;
    [SerializeField] GameObject questNoneSelectedWindow;
    [SerializeField] Sprite[] questIcons = new Sprite[(int)Quest.QUEST_TYPE.ENUM_SIZE];

    [SerializeField] Text questTitleText;
    [SerializeField] Text questNpcText;
    [SerializeField] Text questInfoText;
    [SerializeField] Text questRequireText;
    [SerializeField] Text questPrizeExpText;
    [SerializeField] Text questPrizeGoldText;

    Quest _quest;
    QuestInfo _questInfo;

    public QuestInfo[] QuestInfos { get { return questInfos; } }
    public Sprite[] QuestIcons { get { return questIcons; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ActivateQuestInfoGroup(bool _activate)
    {
        questInfoGroup.SetActive(_activate);
        questNoneSelectedWindow.SetActive(!_activate);
    }

    public void SetQuestInfoGroup(int _questCode)
    {
        questTitleText.text = _quest.QuestTitle;
        questNpcText.text = $"NPC : {_quest.QuestNpc}";
        questInfoText.text = _quest.QuestInfo;
        questRequireText.text = $"";
        questPrizeExpText.text = $"����ġ : {_quest.QuestPrizeExp}";
        questPrizeGoldText.text = $"��� : {_quest.QuestPrizeGold}";

        RefreshRequireText(_questCode);
    }

    void RefreshRequireText(int _questCode)
    {
        _quest = questInfos[_questCode].Quest;
        if (_quest.QuestRequireItem != null)
        {
            // questInfoTexts[3].text = $"{_quest.QuestRequireItem.Item.ItemName} {Inventory.instance.HowManyItem(_quest.QuestRequireItem.Item)}/{_quest.QuestRequireItem.ItemNum} �� �����ϱ�";
        }
    }

    public void CompleteQuest(int _questCode)
    {
        _questInfo = questInfos[_questCode];
        Player.instance.AddExp(_questInfo.Quest.QuestPrizeExp);
    }

    public void StartQuest(int _questCode)
    {
        _questInfo = questInfos[_questCode];
        if (_questInfo.QuestStartable && questInfos.Length < questInfoButtonGroup.transform.childCount)
        {
            AlertManager.instance.ShowAlert($"\"{_questInfo.Quest.QuestTitle}\" ����Ʈ�� �����߽��ϴ�.");
        }
        else
        {
            AlertManager.instance.ShowAlert("����Ʈ�� ������ �� �����ϴ�.");
        }
    }

    [System.Serializable]
    public class QuestInfo
    {
        [SerializeField] Quest quest; // ����Ʈ
        [SerializeField] bool questStartable = false; // ����Ʈ ���� �������� ���� - ���� ����Ʈ �Ϸ� �Ͽ����� üũ
        [SerializeField] bool questContinuing = false; // ����Ʈ ���������� ����
        [SerializeField] bool questCompletable = false; // ����Ʈ �Ϸ� ���� ����
        [SerializeField] bool questCompleted = false; // ����Ʈ �Ϸ� ����
        [SerializeField] int monsterKill = 0; // ���� óġ ��

        public Quest Quest { get { return quest; } }
        public bool QuestStartable { get { return questStartable; } }
        public bool QuestContinuing { get { return questContinuing; } }
        public bool QuestCompletable { get { return questCompletable; } }
        public bool QuestCompleted { get { return questCompleted; } }

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
            /*
            if (quest.QuestRequireItem.ItemNum <= Inventory.instance.HowManyItem(quest.QuestRequireItem.Item))
            {
                questCompletable = true;
            }
            */
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