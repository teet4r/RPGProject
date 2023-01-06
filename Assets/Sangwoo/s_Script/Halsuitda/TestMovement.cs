using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    float rotationSpeed = 45f;
    Vector3 currentEulerAngles;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) x = 1 - x;
        if (Input.GetKeyDown(KeyCode.Y)) y = 1 - y;
        if (Input.GetKeyDown(KeyCode.Z)) z = 1 - z;

        // 속도와 시간을 곱한 입력에 따라 Vector3 수정
        currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;

        //apply the change to the gameObject

        transform.localEulerAngles = currentEulerAngles;

    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        GUI.Label(new Rect(10, 0, 0, 0), "Rotation on X:" + x + "Y:" + y + "Z:" + z, style);
        GUI.Label(new Rect(10, 50, 0, 0), "Transform.localEulerAngle: " + transform.localEulerAngles, style);
    } 



}

