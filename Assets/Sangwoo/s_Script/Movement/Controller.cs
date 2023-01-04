//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Controller : MonoBehaviour
//{
//    [Header("Camera")]
//    public Transform camAxis_Central;
//    public Transform cam;
//    public float camSpeed;
//    float mouseX;
//    float mouseY;

//    public float rotationCamera;
//    public float wheel;


//    [Header("Player")]
//    public Transform playerAxis;
//    public Transform player;
//    public float playerSpeed;
//    public Vector3 movement; 


//    void Start()
//    {
//        wheel = -10;
//        mouseY = 4;
//    }


//    void CamMove()
//    {
//        mouseX += Input.GetAxis("Mouse X");
//        mouseY += Input.GetAxis("Mouse Y") * -1;

//        if (mouseY > 10)
//            mouseY = 10;
//        if (mouseY < 0)
//            mouseY = 0;

//        camAxis_Central.rotation = Quaternion.Euler(new Vector3(camAxis_Central.rotation.x
//                  + mouseY, camAxis_Central.rotation.y + mouseX, 0) * camSpeed);
//    }


//    void Zoom()
//    {
//        wheel += Input.GetAxis("Mouse ScrollWheel") * 10;
//       // rotationCamera = cam.rotation.x.;
//        if (wheel >= -4)
//        {
//            rotationCamera=+24;
//            wheel = -4; //카메라 낮추기 x: 24 
            
//        }
            
//        if (wheel <= -12)
//            wheel = -12; //카메라 x

//        cam.localPosition = new Vector3(0, 0, wheel);
//    }

//    void PlayerMove()
//    {
//        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

//        if(movement != Vector3.zero)
//        {
//            playerAxis.rotation = Quaternion.Euler(new Vector3(0, camAxis_Central.rotation.y + mouseX, 0) * camSpeed);

//            playerAxis.Translate(movement * Time.deltaTime * playerSpeed);

//            player.localRotation = Quaternion.Slerp(player.localRotation, Quaternion.LookRotation(movement), 5 * Time.deltaTime);

//            player.GetComponent<Animator>().SetBool("Walk", true);
//        }

//        if (movement == Vector3.zero)
//            player.GetComponent<Animator>().SetBool("Walk", false);  

//        camAxis_Central.position = new Vector3(player.position.x, player.position.y + 4, player.position.z);

//    }

//    void Update()
//    {
//        CamMove();
//        Zoom();
//        PlayerMove();
//    }
//}
