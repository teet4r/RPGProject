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

    //ī�޶� ����� �Ұ�
    //public float rot_speed = 100.0f;

    //public GameObject Player;
    //public GameObject MainCamera;

    //private float camera_dist = 0f; 
    //public float camera_width = -10f; 
    //public float camera_height = 4f; 
    //public float camera_fix = 3f;

    //Vector3 dir;


    void Start()
    {
        //player Tag
        //Player = GameObject.FindGameObjectWithTag("Player");
        //MainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //camera_dist = Mathf.Sqrt(camera_width * camera_width +
        //    camera_height * camera_height);
        //dir = new Vector3(0, camera_height, camera_width).normalized;
        ////////////////////////////////
       

        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;
        

        directionNormalized = realCamera.localPosition.normalized;
        finalDistance = realCamera.localPosition.magnitude; //magnitude(ũ��)
        LockCursor();
    }


    void Update()
    {
        //
        //transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rot_speed, Space.World);
        //transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * Time.deltaTime * rot_speed, Space.Self);
        //transform.position = Player.transform.position;
        //
        ///////////////////////////////
        //����ĳ��Ʈ�� ���Ͱ�
        //Vector3 ray_target = transform.up * camera_height + transform.forward * camera_width;
        //Debug.Log("ray_target : " + ray_target);

        //RaycastHit hitinfo;
        //Physics.Raycast(transform.position, ray_target, out hitinfo, camera_dist);

        //if (hitinfo.point != Vector3.zero)//�����ɽ�Ʈ ������
        //{
        //    //point�� �ű��.
        //    MainCamera.transform.position = hitinfo.point;
        //    //ī�޶� ����
        //    MainCamera.transform.Translate(dir * -1 * camera_fix);
        //}
        //else
        //{
        //    //������ǥ�� 0���� �����. (ī�޶󸮱׷� �ű��.)
        //    MainCamera.transform.localPosition = Vector3.zero;
        //    //ī�޶���ġ������ ���⺤�� * ī�޶� �ִ�Ÿ� �� �ű��.
        //    MainCamera.transform.Translate(dir * camera_dist);
        //    //ī�޶� ����
        //    MainCamera.transform.Translate(dir * -1 * camera_fix);

        //}

        /////////////////////////

        if (UIInputManager.instance.CheckUIOpen())
        {
            UnLockCursor();
        }
        else
        {
            LockCursor();
            rotX += -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;
            rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
            Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
            transform.rotation = rot;
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, followSpeed );

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
        realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, directionNormalized * finalDistance,0.5f);
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
