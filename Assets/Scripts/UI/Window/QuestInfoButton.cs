using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestInfoButton : MonoBehaviour
{
    // 작성자 : 김두현
    // NPC 퀘스트 수락 버튼에서 QuestInfoButton sample = new QuestInfoButton(Quest _quest); 를 호출하여 사용

    Quest quest;
    [SerializeField] Text questTitle;
    [SerializeField] Image questImage;

    QuestInfoButton(Quest _quest)
    {
        quest = _quest;
        SetButton();
    }

    void SetButton()
    {
        questImage.sprite = QuestManager.instance.QuestIcons[(int)quest.QuestType];
    }

    public void SelectButton()
    {
        QuestManager.instance.ActivateQuestInfoGroup(true);
    }
}
