using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public static TalkManager instance = null;

    [SerializeField] GameObject npcTalkPanel;
    [SerializeField] Text talkText;
    [SerializeField] Text npcNameText;
    [SerializeField] GameObject buttonGroup;

    enum TALK_BUTTON { TALK_NEXT, TALK_EXIT, QUEST_REJECT, QUEST_ACCEPT, QUEST_PRIZE_ACCEPT, ENUM_SIZE }

    private void Awake()
    {
        instance = this;
    }

    public void PlayTalk(Npc.NPC_TYPE _npcType)
    {
        npcTalkPanel.SetActive(true);
        DisableButtons();
        SetNpcTalkPanel(_npcType);
    }

    void DisableButtons()
    {
        for (int i = 0; i < (int)TALK_BUTTON.ENUM_SIZE; i++)
        {
            buttonGroup.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void SetNpcTalkPanel(Npc.NPC_TYPE _npcType)
    {
        QuestManager.instance.QuestInfos.GetValue(_npcType);
    }
}