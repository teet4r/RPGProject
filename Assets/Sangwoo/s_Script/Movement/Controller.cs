using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Camera")]
    public Transform camAxis_Central;
    public Transform cam;
    public float camSpeed;
    float mouseX;
    float mouseY;

    public float rotationCamera;
    public float wheel;



    void Start()
    {
        wheel = -10;
        mouseY = 4;
    }


    

    void Zoom()
    {
        wheel += Input.GetAxis("Mouse ScrollWheel") * 10;
        // rotationCamera = cam.rotation.x.;
        if (wheel >= -4)
        {
            rotationCamera = +24;
            wheel = -4; //카메라 낮추기 x: 24 

        }

        if (wheel <= -12)
            wheel = -12; //카메라 x

        cam.localPosition = new Vector3(0, 0, wheel);
    }

   

    void Update()
    {
       
        Zoom();
      
    }
}
