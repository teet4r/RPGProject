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

    private void Awake()
    {
        instance = this;
    }

    public void PlayTalk(Npc _npc)
    {
        for(int i=0;i<_npc.Quests.Length;i++)
        {
            if (QuestManager.instance.IsCompletedQuest(_npc.Quests[i].QuestCode))
            {
                continue;
            }
            else if (QuestManager.instance.IsCompletableQuest(_npc.Quests[i].QuestCode))
            {
                PlayCompletableTalk(_npc.Quests[i]);
            }
            else if (QuestManager.instance.IsContinuingQuest(_npc.Quests[i].QuestCode))
            {
                PlayContinuingTalk(_npc.Quests[i]);
            }
            else if (QuestManager.instance.IsStartableQuest(_npc.Quests[i].QuestCode))
            {
                PlayStartableTalk(_npc.Quests[i]);
            }
        }
        return;
    }

    void PlayStartableTalk(Quest _quest)
    {

    }

    void PlayContinuingTalk(Quest _quest)
    {
    }

    void PlayCompletableTalk(Quest _quest)
    {
    }
}