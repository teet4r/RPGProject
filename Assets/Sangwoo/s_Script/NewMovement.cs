using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NewMovement : MonoBehaviour
{
    private CharacterController controller;
    private new Transform transform;
    private Animator animator;
    private new Camera camera;

    private Plane plane; //가상의 plane에 레이 캐스팅 하기 위한 변수
    private Ray ray;
    private Vector3 hitPoint;
    public float moveSpeed = 10f;

   
    private CinemachineVirtualCamera virtualCamera;
    private Vector3 CurPos;
    private Quaternion CurRot;
    public float damping = 10.0f;
    private Transform tr;
    void Start()
    {
        tr = this.transform;
        controller = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        camera = Camera.main;
        //PV = GetComponent<PhotonView>();
      
        virtualCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
       

        plane = new Plane(transform.up, transform.position);
        //가상의 바닥을 주인공 위치를 기준으로 생성

    }


    void Update()
    {
        Move();
        Turn();
       
       
            //수신된 좌표로   보간한 이동처리
            tr.position = Vector3.Lerp(tr.position, CurPos, Time.deltaTime * damping);
            //수신된 회전값으로 보간한 회전처리
            tr.rotation = Quaternion.Slerp(tr.rotation, CurRot, Time.deltaTime * damping);
      

    }
    float h => Input.GetAxis("Horizontal");
    float v => Input.GetAxis("Vertical");

    void Move()
    {
        Vector3 cameraForward = camera.transform.forward;
        Vector3 cameraRight = camera.transform.right;
        cameraForward.y = 0.0f;
        cameraRight.y = 0.0f;
        //이동할 방향 벡터 계산
        Vector3 moveDir = (cameraForward * v) + (cameraRight * h);
        moveDir.Set(moveDir.x, 0f, moveDir.z);
        //주인공 캐릭터 이동 처리
        controller.SimpleMove(moveDir * moveSpeed);

        //주인공 캐릭터 애니메이션 처리
        float forward = Vector3.Dot(moveDir, transform.forward);
        float strafe = Vector3.Dot(moveDir, transform.right);

        animator.SetFloat("Forward", forward);
        animator.SetFloat("Strafe", strafe);


    }

    void Turn()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        //가상의 바닥에 광선을 발사해 충돌하는 지점의 거리를 enter변수로
        //변환
        plane.Raycast(ray, out enter);
        //가상의 바닥에 레이가 충돌한 좌표값 추출
        hitPoint = ray.GetPoint(enter);

        Vector3 lookDir = hitPoint - transform.position;
        lookDir.y = 0;
        //주인공 캐릭터의 화전값 지정
        transform.localRotation = Quaternion.LookRotation(lookDir);

    }

   
   
}
