using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyText : MonoBehaviour
{
    [SerializeField] int quickSlotNum;
    private void Update()
    {
        // GetComponent<Text>().text = KeyManager.instance.Key((KeyManager.KEYNAME)quickSlotNum).ToString();
    }
}