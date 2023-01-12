using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestInfoButton : MonoBehaviour
{
    // �ۼ��� : �����

    [SerializeField] Quest quest;
    [SerializeField] Text questTitle;
    [SerializeField] Image questImage;

    int questCode;

    public void SetButton(int _questCode)
    {
        quest = QuestManager.instance.QuestInfos[_questCode].Quest;
        questImage.sprite = QuestManager.instance.QuestIcons[(int)quest.QuestType];
        questTitle.text = quest.QuestTitle;
        questCode = _questCode;
    }

    public void SelectButton()
    {
        QuestManager.instance.ActivateQuestInfoGroup(true);
        QuestManager.instance.SetQuestInfoGroup(questCode);
    }
}