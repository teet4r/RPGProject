using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AlertManager.instance.ShowAlert("��ȭ�� �����մϴ�.");
        }
    }
}