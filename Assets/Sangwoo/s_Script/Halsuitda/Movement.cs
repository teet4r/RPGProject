using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //�ۼ���: �̻��
    //�ۼ���: 22-12-29

    //public float InputX;
    //public float InputY;
    [SerializeField] //���ϸ����� (������Ʈ)�ҷ��Ë� �����
    Animator animator;
    [SerializeField]
    Rigidbody rigidy;
    [SerializeField]
    Player player;
   
    float h, v, r; //vector���� �����ϱ� ���ؼ� (h=ȣ������,v=��Ƽ��,r=���콺ȣ������(ȸ��)) (�̵�)
    public float smoothBlend = 0.1f; //�ִϸ��̼� time.deltatime�� ���� ���� ������ �ε巯����
    public float moveSpeed = 3f;  //�����ϋ� �ӵ�
    public float turnSpeed = 90f;
    public float rollSpeed = 10f; //������ �ӵ�
    public bool IsSprint;   //�޸���� �ӵ��� +=���ֱ�

    Animator _animator;
    Camera _camera;
    CharacterController _controller;

    public float Speed = 5f;
    public float runSpeed = 8f;
    public bool toggleCameraRotation;
    public float smoothness = 10f;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _camera = Camera.main;
        _controller = this.GetComponent<CharacterController>();
    }
    void Update()
    {
        if (!player.isAlive) return;
        
        Move();
        Roll();
        

    }
    void Move()
    {
        
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime);
        {
            animator.SetFloat("SpeedX", h, smoothBlend, Time.deltaTime);

        }
        transform.Translate(Vector3.forward.normalized * v * moveSpeed * Time.deltaTime);
        {
            animator.SetFloat("SpeedY", v, smoothBlend, Time.deltaTime);
        }
        transform.Rotate(Vector3.up * r * Time.deltaTime * turnSpeed);

        Sprint();
        Shield();


    }
    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            moveSpeed =7f;
            animator.SetBool("IsSprint", true);
            Player.instance.DecreaseSp(10*Time.deltaTime);
            
            // Debug.Log(Player.instance.NowSp);

          
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W))
        {
            moveSpeed = 3.5f;
            animator.SetBool("IsSprint", false);

        }
    }
    void Roll()
    {
        //����
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsRolling_F", true);
            rigidy.AddForce(transform.forward * rollSpeed,ForceMode.Impulse);
            
            Player.instance.DecreaseSp(25f);
            Debug.Log("���¹̳� 25");
            Debug.Log(Vector3.forward * rollSpeed);

        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsRolling_F", false);


        }
        //�ĸ�
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsRolling_B", true);
            
            rigidy.AddForce(transform.forward*-1 * rollSpeed,ForceMode.Impulse);
            Player.instance.DecreaseSp(25f);
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsRolling_B", false);

        }
        //����
        if (Input.GetKeyDown(KeyCode.Space)&&Input.GetKey(KeyCode.A))
       {
            animator.SetBool("IsRolling_L", true);
            
            rigidy.AddForce(transform.right*-1 * rollSpeed, ForceMode.Impulse);
            Player.instance.DecreaseSp(25f);
        }
       else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.A))
       {
            animator.SetBool("IsRolling_L", false);

       }
       //������
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsRolling_R", true);
            rigidy.AddForce(transform.right * rollSpeed, ForceMode.Impulse);
            Player.instance.DecreaseSp(25f);

        }
        else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsRolling_R", false);

        }
    }

    void Shield()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsShield", true);
            Debug.Log(Player.instance.NowSp);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("IsShield", false);
        }
    }
}
