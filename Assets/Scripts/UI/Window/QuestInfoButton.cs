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

    private void Start()
    {
        SetButton(1, 1);
    }

    public void SetButton(int npcType,int _questCode)
    {
        quest = QuestManager.instance.QuestInfos[npcType][_questCode].Quest;
        questImage.sprite = QuestManager.instance.QuestIcons[(int)quest.QuestType];
        questTitle.text = quest.QuestTitle;
    }

    public void SelectButton()
    {
        QuestManager.instance.ActivateQuestInfoGroup(true);
        QuestManager.instance.SetQuestInfoGroup(1,1);
    }
}