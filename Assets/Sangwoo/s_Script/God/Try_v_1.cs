using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]
public class Try_v_1 : MonoBehaviour
{
    public float InputX;
    public float InputZ;



    [Header("Player")]
    public Transform playerAxis;
    public Transform player;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed = 0.1f;
    public Animator anim;
    public float Speed;
    public float allowPlayerRotation = 0.1f;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;

    //중력추가
    public float Gravity = -9.8f; //중력계수

    //애니메이션 
    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimationSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    private float verticalVel;
    private Vector3 moveVector;

    //애니메이션 지정
    const int ANI_IDLE = 0;
    const int ANI_WALK = 1;


    
    void Start()
    {
        anim = this.GetComponent<Animator>();
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
    }

  
    void Update()
    {
        InputMangnitude();
        chracterGround();

    }

    //카메라 조작
    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        //카메라가 보는 방향이 앞이다
        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

       

       // if(GetComponent<ThrowController>().aiming)
           // return;



        //공격할때 무기를 던지거나 활을쏠때 에임이고정되면서 움직임을 멈춘다.
        if(blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * 3);
        }
    }

    //카메라 회전 
    public void RotateToCamera(Transform t)
    {
        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        desiredMoveDirection = forward;
        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }

    void chracterGround()
    {
        //중력추가해주기
        if(controller.isGrounded == false)
        {
            moveVector.y += Gravity * Time.deltaTime;
        }
        controller.Move(moveVector * Speed * Time.deltaTime);

        //캐릭터가 땅에 다야 움직일수 있으니까 애니메이션을 이함수에 
        //controller.GetComponent<Animator>().SetBool("walking",true);
    }



    void InputMangnitude() 
    {
        //Calculate Input Vectors 입력백터값 계산
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        if(Speed >allowPlayerRotation)
        {
            PlayerMoveAndRotation();
        }
        else if(Speed< allowPlayerRotation)
        {

        }
    }
}
