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
