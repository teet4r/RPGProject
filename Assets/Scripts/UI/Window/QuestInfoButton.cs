using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestInfoButton : MonoBehaviour
{
    // 작성자 : 김두현

    [SerializeField] Quest quest;
    [SerializeField] Text questTitle;
    [SerializeField] Image questImage;

    private void Start()
    {
        SetButton(2);
    }

    public void SetButton(int _questCode)
    {
        quest = QuestManager.instance.QuestInfos[_questCode].Quest;
        questImage.sprite = QuestManager.instance.QuestIcons[(int)quest.QuestType];
        questTitle.text = quest.QuestTitle;
    }

    public void SelectButton()
    {
        QuestManager.instance.ActivateQuestInfoGroup(true);
        QuestManager.instance.SetQuestInfoGroup(2);
    }
}