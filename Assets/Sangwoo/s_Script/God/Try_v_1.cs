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

    //�߷��߰�
    public float Gravity = -9.8f; //�߷°��

    //�ִϸ��̼� 
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

    //�ִϸ��̼� ����
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

    //ī�޶� ����
    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        //ī�޶� ���� ������ ���̴�
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



        //�����Ҷ� ���⸦ �����ų� Ȱ���� �����̰����Ǹ鼭 �������� �����.
        if(blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * 3);
        }
    }

    //ī�޶� ȸ�� 
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
        //�߷��߰����ֱ�
        if(controller.isGrounded == false)
        {
            moveVector.y += Gravity * Time.deltaTime;
        }
        controller.Move(moveVector * Speed * Time.deltaTime);

        //ĳ���Ͱ� ���� �پ� �����ϼ� �����ϱ� �ִϸ��̼��� ���Լ��� 
        //controller.GetComponent<Animator>().SetBool("walking",true);
    }



    void InputMangnitude() 
    {
        //Calculate Input Vectors �Է¹��Ͱ� ���
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
