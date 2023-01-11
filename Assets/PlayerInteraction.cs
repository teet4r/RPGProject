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
                Debug.Log("HI5");
                interactionWindow.gameObject.SetActive(true);
                interactionWindow.SetInteractionWindow(GetNearestNpc());
            }
            else
            {
                Debug.Log("HI5");
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
        GameObject nearestNpc = null;
        for (int i = 0; i < npcs.Count; i++)
        {
            distance = Vector3.Distance(playerPos, npcs[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestNpc = npcs[i].gameObject;
            }
        }
        Debug.Log(nearestNpc);
        if (nearestNpc != null)
        {
            Debug.Log("HI3");
            return nearestNpc;
        }
        else
        {
            Debug.Log("HI4");
            return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC") || other.gameObject.CompareTag("Merchant"))
        {
            Debug.Log("HI1");
            npcs.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC") || other.gameObject.CompareTag("Merchant"))
        {
            Debug.Log("HI2");
            npcs.Remove(other.gameObject);
        }
    }
}