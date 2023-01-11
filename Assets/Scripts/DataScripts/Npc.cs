using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC/Npc")]
public class Npc : ScriptableObject
{
    [SerializeField] string npcName;
    [SerializeField] Quest[] quests;
    [SerializeField] Big[] bigs;
    [SerializeField] string npcInfo;

    public string NpcName { get { return npcName; } }
    public Quest[] Quests { get { return quests; } }
    public Big[] Bigs { get { return bigs; } }
    public string NpcInfo { get { return npcInfo; } }

    [System.Serializable]
    public class Small
    {
        [SerializeField] string npcScript;
        [SerializeField] bool isNpc = true; //npc가 말할 때 켜지고 유저가 말할 때 꺼지고
        public string NpcScript { get { return npcScript; } }
        public bool IsNpc { get { return isNpc;} }
    }

    [System.Serializable]
    public class Big
    {
        [SerializeField] Small[] smalls;
        [SerializeField] bool isClear = false;
        [SerializeField] Small[] clearMessage;
        public Small[] Smalls { get { return smalls; } }
        public bool IsClear { get { return isClear; } }
        public Small[] ClearMessage { get { return clearMessage; } }
    }
}