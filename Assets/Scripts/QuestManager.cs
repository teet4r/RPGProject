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
        questInfoTexts[3].text = _quest.QuestRequireItem.Item.ItemName + ' '; // ����
        questInfoTexts[5].text = "����ġ : " + _quest.QuestPrizeExp.ToString();
        questInfoTexts[6].text = "��� : " + _quest.QuestPrizeGold.ToString();
    }

    void RefreshRequireText()
    {
    }

    [System.Serializable]
    public class QuestInfo
    {
        [SerializeField] Quest quest; // ����Ʈ
        [SerializeField] bool questStartable = false; // ����Ʈ ���� �������� ���� - ���� ����Ʈ �Ϸ� �Ͽ����� üũ
        [SerializeField] bool questCompletable = false; // ����Ʈ �Ϸ� ���� ����
        [SerializeField] bool questComplete = false; // ����Ʈ �Ϸ� ����
        [SerializeField] int monsterKill = 0; // ���� óġ ��
        [SerializeField] int itemNum = 0; // ������ ����

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