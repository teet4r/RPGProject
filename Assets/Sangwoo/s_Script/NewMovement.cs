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

    private Plane plane; //������ plane�� ���� ĳ���� �ϱ� ���� ����
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
        //������ �ٴ��� ���ΰ� ��ġ�� �������� ����

    }


    void Update()
    {
        Move();
        Turn();
       
       
            //���ŵ� ��ǥ��   ������ �̵�ó��
            tr.position = Vector3.Lerp(tr.position, CurPos, Time.deltaTime * damping);
            //���ŵ� ȸ�������� ������ ȸ��ó��
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
        //�̵��� ���� ���� ���
        Vector3 moveDir = (cameraForward * v) + (cameraRight * h);
        moveDir.Set(moveDir.x, 0f, moveDir.z);
        //���ΰ� ĳ���� �̵� ó��
        controller.SimpleMove(moveDir * moveSpeed);

        //���ΰ� ĳ���� �ִϸ��̼� ó��
        float forward = Vector3.Dot(moveDir, transform.forward);
        float strafe = Vector3.Dot(moveDir, transform.right);

        animator.SetFloat("Forward", forward);
        animator.SetFloat("Strafe", strafe);


    }

    void Turn()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        //������ �ٴڿ� ������ �߻��� �浹�ϴ� ������ �Ÿ��� enter������
        //��ȯ
        plane.Raycast(ray, out enter);
        //������ �ٴڿ� ���̰� �浹�� ��ǥ�� ����
        hitPoint = ray.GetPoint(enter);

        Vector3 lookDir = hitPoint - transform.position;
        lookDir.y = 0;
        //���ΰ� ĳ������ ȭ���� ����
        transform.localRotation = Quaternion.LookRotation(lookDir);

    }

   
   
}
