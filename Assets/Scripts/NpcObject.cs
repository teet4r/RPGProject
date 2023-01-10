using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcObject : MonoBehaviour
{
    [SerializeField] Npc npc;

    public Npc Npc { get { return npc; } }
}