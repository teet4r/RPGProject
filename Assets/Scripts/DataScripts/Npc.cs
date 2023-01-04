using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC/Npc")]
public class Npc : ScriptableObject
{
    [SerializeField] string npcName;
    [SerializeField] NPC_TYPE npcType;
    [SerializeField] Quest[] quests;
    public enum NPC_TYPE { NORMAL, MERCHANT }

    public string NpcName { get { return npcName; } }
    public NPC_TYPE NpcType { get { return npcType; } }
    public Quest[] Quests { get { return quests; } }

    [System.Serializable]
    public class NpcScript
    {
        [SerializeField] string[] npcScript;
        [SerializeField] NPC_SCRIPT_TYPE npcScriptType;
        public enum NPC_SCRIPT_TYPE { NORMAL, QUEST }
    }
}