using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TpsCamera : MonoBehaviour
{
    //public CinemachineFreeLook CFreeLook;
    //private float xRotate, yRotate, xRotateMove, yRotateMove;
    //public float rotateSpeed = 500.0f;

    //void Update()
    //{
    //    if(Input.GetMouseButton(0))//클릭한 경우
    //    {
    //        //CFreeLook.transform.Rotate(xRotate, 
    //        xRotate = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
    //        yRotate = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

    //        yRotate = yRotate + yRotateMove;
    //        xRotate = xRotate + xRotateMove;

    //        xRotate = Mathf.Clamp(xRotate, -90, 90);

    //        Quaternion quat = Quaternion.Euler(new Vector3(xRotate, yRotate, 0));
    //        transform.rotation = Quaternion.Slerp(transform.rotation, quat, Time.deltaTime);

    //    }

    //}

    CinemachineFreeLook freeLook;
    void Awake()
    {
       //CinemachineCore.GetInputAxis = clickControl;


        // Target 설정
        freeLook = this.GetComponent<CinemachineFreeLook>();
        freeLook.Follow = GameObject.Find("Player").transform;
        freeLook.LookAt = GameObject.Find("LookAt").transform;

        // Lens 설정
        freeLook.m_Lens.FieldOfView = 50;
        freeLook.m_Lens.NearClipPlane = 0.2f;
        freeLook.m_Lens.FarClipPlane = 4000;
        freeLook.m_Lens.Dutch = 0;
        freeLook.m_Lens.ModeOverride = LensSettings.OverrideModes.None;

        // Axis Control 설정
        freeLook.m_XAxis.Value = 0;
        freeLook.m_XAxis.m_MaxSpeed = 300;
        freeLook.m_XAxis.m_AccelTime = 0.1f;

        // Rig 설정
        CinemachineComposer composer
            = freeLook.GetRig(1).GetCinemachineComponent<CinemachineComposer>();
        composer.m_DeadZoneHeight = 0.3f;
        composer.m_DeadZoneWidth = 0.5f;
    }

    public float clickControl(string axis)
    {
        if (Input.GetMouseButton(0))
            return UnityEngine.Input.GetAxis(axis);

        return 0;
    }
}

  