using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKey : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyManager.instance.Key(KeyManager.KEYNAME.CHAR_ATTACK)))
        {
            Debug.Log("HI");
        }
    }
}