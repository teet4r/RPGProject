using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    // �ۼ��� : �����
    public static QuestManager instance;

    [SerializeField] GameObject questInfoButton;

    [SerializeField] GameObject questList;

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
    [SerializeField] GameObject itemslotGroup;

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
        Quest _quest = questInfos[_questCode].Quest;
        questTitleText.text = _quest.QuestTitle;
        questNpcText.text = $"NPC : {_quest.QuestNpc}";
        questInfoText.text = _quest.QuestInfo;
        questRequireText.text = $"";
        for(int i=0;i<_quest.QuestRequireMonster.Length;i++)
        {
            questRequireText.text += $"{_quest.QuestRequireMonster[i].Monster.MonsterName} {_quest.QuestRequireMonster[i].MonsterNum}���� ����ϱ� {questInfos[_questCode].MonsterKill[i]}/{_quest.QuestRequireMonster[i].MonsterNum}\n";
        }
        for (int i = 0; i < _quest.QuestRequireItem.Length; i++)
        {
            questRequireText.text += $"{_quest.QuestRequireItem[i].Item.ItemName} {_quest.QuestRequireItem[i].ItemNum}�� �����ϱ� {Inventory.instance.HowManyItem(_quest.QuestRequireItem[i].Item)}/{1}\n";
        }
        questPrizeExpText.text = $"����ġ : {_quest.QuestPrizeExp}";
        questPrizeGoldText.text = $"��� : {_quest.QuestPrizeGold}";
        if (_quest.QuestPrizeItems.Length == 0)
        {
            for (int i = 0; i < itemslotGroup.GetComponentsInChildren<ItemSlot>().Length; i++)
            {
                itemslotGroup.GetComponentsInChildren<ItemSlot>()[i].ClearItemSlot();
            }
        }
        for (int i = 0; i < _quest.QuestPrizeItems.Length; i++)
        {
            itemslotGroup.GetComponentsInChildren<ItemSlot>()[i].SetItem(_quest.QuestPrizeItems[i].Item, _quest.QuestPrizeItems[i].ItemNum);
        }
    }

    string[] RefreshRequireText(int _questCode)
    {
        Quest _quest = questInfos[_questCode].Quest;
        string[] requireTexts = null;
        int num = 0;
        if (_quest.QuestRequireMonster != null)
        {
            for (int i = 0; i < _quest.QuestRequireMonster.Length; i++)
            {
                requireTexts[num++] = $"{_quest.QuestRequireMonster[i].Monster.MonsterName} ����ϱ� {questInfos[_questCode].MonsterKill}/{_quest.QuestRequireMonster[i].MonsterNum}";
            }
        }
        if (_quest.QuestRequireItem != null)
        {
            for (int i = 0; i < _quest.QuestRequireItem.Length; i++)
            {
                requireTexts[num++] = $"{_quest.QuestRequireItem[i].Item.ItemName} �����ϱ� {Inventory.instance.HowManyItem(_quest.QuestRequireItem[i].Item)}/{_quest.QuestRequireItem[i].ItemNum}";
            }
        }
        return requireTexts;
    }

    public void CompleteQuest(int _questCode)
    {
        QuestInfo _questInfo = questInfos[_questCode];
        _questInfo.SetQuestCompleted();
        Player.instance.AddExp(_questInfo.Quest.QuestPrizeExp);
        Inventory.instance.AddGold(_questInfo.Quest.QuestPrizeGold);
    }

    public void StartQuest(int _questCode)
    {
        QuestInfo _questInfo = questInfos[_questCode];
        if (_questInfo.QuestStartable)
        {
            GameObject tmpObj = Instantiate(questInfoButton, Vector3.zero, Quaternion.identity, questInfoButtonGroup.transform);
            tmpObj.GetComponent<QuestInfoButton>().SetButton(_questCode);
            questList.GetComponent<QuestList>().CreateQuickQuestInfo(_questInfo);
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
        [SerializeField] int[] monsterKill; // ���� óġ ��

        public Quest Quest { get { return quest; } }
        public bool QuestStartable { get { return questStartable; } }
        public bool QuestContinuing { get { return questContinuing; } }
        public bool QuestCompletable { get { return questCompletable; } }
        public bool QuestCompleted { get { return questCompleted; } }
        public int[] MonsterKill { get { return monsterKill; } }

        public void RefreshQuest()
        {
            SetQuestStartable();
        }

        public void KillMonster()
        {
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
            for(int i=0;i<quest.QuestRequireMonster.Length;i++)
            {
                monsterKill[i] = 0;
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