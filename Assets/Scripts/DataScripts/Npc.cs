using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC/Npc")]
public class Npc : ScriptableObject
{
    [SerializeField] string npcName;
    [SerializeField] SerializableDictionary<Quest, QuestScript> quests;
    [SerializeField] string npcInfo;
    [SerializeField] NPC_TYPE npcType;

    public string NpcName { get { return npcName; } }
    public SerializableDictionary<Quest,QuestScript> Quests { get { return quests; } }
    public string NpcInfo { get { return npcInfo; } }
    public NPC_TYPE NpcType { get { return npcType; } }

    public enum NPC_TYPE { JANGRO, GIRL }

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
        [SerializeField] bool isNpc = true; //npc�� ���� �� ������ ������ ���� �� ������
        public string Script { get { return script; } }
        public bool IsNpc { get { return isNpc;} }
    }
}