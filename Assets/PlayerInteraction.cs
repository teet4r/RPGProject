using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("NPC"))
        {

            Debug.Log("npc�Դϴ�");

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            Debug.Log("npc Exit �Դϴ�");

        }
    }

}
