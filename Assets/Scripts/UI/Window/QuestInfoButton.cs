using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestInfoButton : MonoBehaviour
{
    // 작성자 : 김두현

    Npc.NPC_TYPE npcType;
    [SerializeField] Quest quest;
    [SerializeField] Text questTitle;
    [SerializeField] Image questImage;

    public void SetButton(Npc.NPC_TYPE _npcType, Quest _quest)
    {
        npcType = _npcType;
        quest = _quest;
        questImage.sprite = QuestManager.instance.QuestIcons[(int)quest.QuestType];
        questTitle.text = quest.QuestTitle;
    }

    public void SelectButton()
    {
        QuestManager.instance.ActivateQuestInfoGroup(true);
        QuestManager.instance.SetQuestInfoGroup(npcType, quest.QuestCode);
    }
}