using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform objFollow;
    public float flwSpeed = 10f;
    public float sens = 100f;
    public float clampAngle = 70f;

    private float rotX;
    private float rotY;

    public Transform realCamera;
    public Vector3 dirNormalized;
    public Vector3 finalDir;
    public float minDis;
    public float maxDis;
    public float finalDis;

    void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = realCamera.localPosition.normalized;
        finalDis = realCamera.localPosition.magnitude;
    }

    
    void Update()
    {
        rotX += Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
        rotY += Input.GetAxis("Mouse X") * sens * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
        transform.rotation = rot;
    }

    void LatUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.)
    }
}
