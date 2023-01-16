using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC/Npc")]
public class Npc : ScriptableObject
{
    [SerializeField] string npcName;
    [SerializeField] Quest[] quests;
    [SerializeField] QuestScript[] questScripts;
    [SerializeField] string npcInfo;

    public string NpcName { get { return npcName; } }
    public Quest[] Quests { get { return quests; } }
    public QuestScript[] QuestScripts { get { return questScripts; } }
    public string NpcInfo { get { return npcInfo; } }


    [System.Serializable]
    public class QuestScript
    {
        [SerializeField] NpcScript[] startMessages;
        [SerializeField] NpcScript[] continueMessages;
        [SerializeField] NpcScript[] clearMessages;
        public NpcScript[] StartMessages { get { return startMessages; } }
        public NpcScript[] ContinueMessages { get { return continueMessages; } }
        public NpcScript[] ClearMessages { get { return clearMessages; } }
    }

    [System.Serializable]
    public class NpcScript
    {
        [SerializeField] string script;
        [SerializeField] bool isNpc = true; //npc가 말할 때 켜지고 유저가 말할 때 꺼지고
        public string Script { get { return script; } }
        public bool IsNpc { get { return isNpc;} }
    }
}