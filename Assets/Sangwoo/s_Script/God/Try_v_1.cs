using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Try_v_1 : MonoBehaviour
{
    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed = 0.1f;
    public Animator anim;
    public float Speed;
    public float allowPlayerRotation = 0.1f;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;

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



    void Start()
    {
        anim = this.GetComponent<Animator>();
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
    }

  
    void Update()
    {
        InputMangnitude();
        PlayerMoveAndRotation();
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

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

        if(blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * 3);
        }
    }

    public void RotateToCamera(Transform t)
    {
        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        desiredMoveDirection = forward;
        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }

    void InputMangnitude() 
    {
        //Calculate Input Vectors
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
