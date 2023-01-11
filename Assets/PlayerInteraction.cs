using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] InteractionWindow interactionWindow;

    List<GameObject> npcs = new();
    [SerializeField] Npc npc;
    public Npc Npc { get { return npc; } }

    private void Start()
    {
        npcs.Clear();
        StartCoroutine(CheckNpc());
    }

    private void Update()
    {
        if (interactionWindow.gameObject.activeSelf && Input.GetKeyDown(KeyManager.instance.Key(KeyManager.KEYNAME.NORM_INTERACTION)) && npcs.Count > 0)
        { 
            if (npcs[0].GetComponent<NpcObject>())
            {
                // NPC ¥Î»≠
                npc = npcs[0].GetComponent<NpcObject>().Npc;
            }
            else
            {

            }
        }
    }

    IEnumerator CheckNpc()
    {
        while (true)
        {
            if (npcs.Count > 0)
            {
                interactionWindow.gameObject.SetActive(true);
                interactionWindow.SetInteractionWindow(GetNearestNpc());
            }
            else
            {
                interactionWindow.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    GameObject GetNearestNpc()
    {
        Vector3 playerPos = Player.instance.transform.position;
        float distance = 0f;
        float minDistance = Vector3.Distance(playerPos, npcs[0].transform.position);
        GameObject nearestNpc = npcs[0];
        for (int i = 0; i < npcs.Count; i++)
        {
            distance = Vector3.Distance(playerPos, npcs[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestNpc = npcs[i].gameObject;
            }
        }
        if (nearestNpc != null)
        {
            return nearestNpc;
        }
        else
        {
            return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC") || other.gameObject.CompareTag("Merchant"))
        {
            npcs.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC") || other.gameObject.CompareTag("Merchant"))
        {
            npcs.Remove(other.gameObject);
        }
    }
}