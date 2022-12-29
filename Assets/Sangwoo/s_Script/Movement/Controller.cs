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
    float wheel;


    void Start()
    {
        
    }

    
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y") * -1;

        if (mouseY > 10)
            mouseY = 10;
        if (mouseY < 0)
            mouseY = 0;

        camAxis_Central.rotation = Quaternion.Euler(new Vector3(camAxis_Central.rotation.x
                                                + mouseY, camAxis_Central.rotation.y + mouseX, 0) * camSpeed);



    }
}
