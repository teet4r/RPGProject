using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestInfoButton : MonoBehaviour
{
    // �ۼ��� : �����
    // NPC ����Ʈ ���� ��ư���� QuestInfoButton sample = new QuestInfoButton(Quest _quest); �� ȣ���Ͽ� ���

    Quest quest;
    [SerializeField] Text questTitle;
    [SerializeField] Image questImage;

    public void SetButton(int _questCode)
    {
        quest = QuestManager.instance.QuestInfos[_questCode].Quest;
        questImage.sprite = QuestManager.instance.QuestIcons[(int)quest.QuestType];
        questTitle.text = quest.QuestTitle;
    }

    public void SelectButton()
    {
        QuestManager.instance.ActivateQuestInfoGroup(true);
    }
}