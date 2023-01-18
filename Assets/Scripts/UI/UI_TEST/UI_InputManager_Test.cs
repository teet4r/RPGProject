using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InputManager_Test : MonoBehaviour
{
    [SerializeField] GameObject testUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!testUI.gameObject.activeSelf)
            {
                testUI.gameObject.SetActive(true);
                StartCoroutine(testUI.GetComponent<UI_Animation_Test>().PlayResizeBiggerAnimation());
            }
            else
            {
                StartCoroutine(testUI.GetComponent<UI_Animation_Test>().PlayResizeSmallerAnimation());
            }
        }
    }
}