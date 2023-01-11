using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] InteractionWindow interactionWindow;

    List<GameObject> npcs = new();

    private void Start()
    {
        npcs.Clear();
        StartCoroutine(CheckNpc());
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
        }
    }

    GameObject GetNearestNpc()
    {
        Vector3 playerPos = Player.instance.transform.position;
        float distance = 0f;
        float maxDistance = Vector3.Distance(playerPos, npcs[0].transform.position);
        GameObject nearestNpc = null;
        for (int i = 0; i < npcs.Count; i++)
        {
            distance = Vector3.Distance(playerPos, npcs[i].transform.position);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                nearestNpc = npcs[i];
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