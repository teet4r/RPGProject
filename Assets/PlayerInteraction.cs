using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] InteractionWindow interactionWindow;

    Dictionary<GameObject, float> npcs = new();

    private void Update()
    {
        if(npcs.Count>0)
        {
            interactionWindow.gameObject.SetActive(true);
            interactionWindow.SetInteractionWindow();
        }else
        {
            interactionWindow.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("NPC"))
        {
            npcs.Add(col.gameObject, Vector3.Distance(Player.instance.transform.position, col.transform.position));
        }
        else if (col.gameObject.CompareTag("Merchant"))
        {
            npcs.Add(col.gameObject, Vector3.Distance(Player.instance.transform.position, col.transform.position));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            Debug.Log("npc Exit ¿‘¥œ¥Á");
        }
    }
}