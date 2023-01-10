using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform objectToFollow;
    public float followSpeed = 10f;
    public float sensitivity = 100f;
    public float clampAngle = 70f;

    private float rotX;
    private float rotY;

    public Transform realCamera;
    public Vector3 directionNormalized;
    public Vector3 finalDirection;
    public float minDistance;
    public float maxDistance;
    public float finalDistance;
    public float Smoothness = 10f;


    void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        directionNormalized = realCamera.localPosition.normalized;
        finalDistance = realCamera.localPosition.magnitude; //magnitude(Å©±â)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        rotX += -(Input.GetAxis("Mouse Y")) *sensitivity* Time.deltaTime;
        rotY += Input.GetAxis("Mouse X") *sensitivity* Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
        transform.rotation = rot;
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, followSpeed * Time.deltaTime);

        finalDirection = transform.TransformPoint(directionNormalized * maxDistance);

        RaycastHit hit;

        if(Physics.Linecast(transform.position,finalDirection,out hit))
        {
            finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);

        }
        else 
        {
            finalDistance = maxDistance;
        }
        realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, directionNormalized * finalDistance, Time.deltaTime);
    }
}
