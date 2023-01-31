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

    public void PlayTalk(Npc _npc)
    {
        npcTalkPanel.SetActive(true);
        DisableButtons();
        SetNpcTalkPanel(_npc);
    }

    void DisableButtons()
    {
        for (int i = 0; i < (int)TALK_BUTTON.ENUM_SIZE; i++)
        {
            buttonGroup.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void SetNpcTalkPanel(Npc _npc)
    {
        QuestManager.QuestInfo tmpInfo = QuestManager.instance.QuestInfos.GetValue(_npc.NpcType)[0];
        Npc.NpcScript[] tmpTalk;
        if (tmpInfo.QuestStartable)
        {
            tmpTalk = _npc.Quests.GetValue(0).StartMessages;
        }
        else if (tmpInfo.QuestContinuing)
        {
            tmpTalk = _npc.Quests.GetValue(0).ContinueMessages;
        }
        else if (tmpInfo.QuestCompletable)
        {
            tmpTalk = _npc.Quests.GetValue(0).ClearMessages;
        }

    }

    IEnumerator ShowNpcTalk(string _str)
    {
        talkText.text = string.Empty;
        int num = 0;
        while (true)
        {
            if (num >= _str.Length) yield break;
            talkText.text += _str[num++];
            yield return null;
        }
    }
}