using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //�ۼ���: �̻��
    //�ۼ���: 22-12-29

    //public float InputX;
    //public float InputY;
    [SerializeField] //�ڱ��ڽ� ��ġ (������Ʈ)�ҷ��ö� �����
    Transform tr;
    [SerializeField] //���ϸ����� (������Ʈ)�ҷ��Ë� �����
    Animator anit;
    [SerializeField]
    Rigidbody rigidy;
   
    float h, v, r; //vector���� �����ϱ� ���ؼ� (h=ȣ������,v=��Ƽ��,r=���콺ȣ������(ȸ��)) (�̵�)

   //Vector3 move

    public float smoothBlend = 0.1f; //�ִϸ��̼� time.deltatime�� ���� ���� ������ �ε巯����
    public float moveSpeed = 3.5f;  //�����ϋ� �ӵ�
    public float turnSpeed = 90f;
    public float rollSpeed = 10f; //������ �ӵ�

    public bool IsSprint;   //�޸���� �ӵ��� +=���ֱ�
    
    void Start()
    {
        tr = GetComponent<Transform>();
        anit = GetComponent<Animator>();
    }
    
    void Update()
    {
        Move();
        Roll();
    }

    void Move()
    {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        tr.Translate(Vector3.right * h * moveSpeed * Time.deltaTime);
        {
            anit.SetFloat("SpeedX", h, smoothBlend, Time.deltaTime);

        }
        tr.Translate(Vector3.forward.normalized * v * moveSpeed * Time.deltaTime);
        {
            anit.SetFloat("SpeedY", v, smoothBlend, Time.deltaTime);
        }
        tr.Rotate(Vector3.up * r * Time.deltaTime * turnSpeed);

        Sprint();
    }


    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            moveSpeed = 5f;
            anit.SetBool("IsSprint", true);
            Player.instance.DecreaseSp(10*Time.deltaTime);
            
            Debug.Log(Player.instance.NowSp);

          
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W))
        {
            moveSpeed = 3.5f;
            anit.SetBool("IsSprint", false);

        }
    }


    void Roll()
    {
        //����
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W))
        {
            anit.SetBool("IsRolling_F", true);
            rigidy.AddForce(transform.forward * rollSpeed,ForceMode.Impulse);
            
            Player.instance.DecreaseSp(25f);
            Debug.Log("���¹̳� 25");
            Debug.Log(Vector3.forward * rollSpeed);

        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            anit.SetBool("IsRolling_F", false);


        }
        //�ĸ�
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {
            anit.SetBool("IsRolling_B", true);
            
            rigidy.AddForce(transform.forward*-1 * rollSpeed,ForceMode.Impulse);
            Player.instance.DecreaseSp(25f);
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.S))
        {
            anit.SetBool("IsRolling_B", false);

        }
        //����
        if (Input.GetKeyDown(KeyCode.Space)&&Input.GetKey(KeyCode.A))
       {
            anit.SetBool("IsRolling_L", true);
            
            rigidy.AddForce(transform.right*-1 * rollSpeed, ForceMode.Impulse);
            Player.instance.DecreaseSp(25f);
        }
       else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.A))
       {
            anit.SetBool("IsRolling_L", false);

       }
       //������
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D))
        {
            anit.SetBool("IsRolling_R", true);
            rigidy.AddForce(transform.right * rollSpeed, ForceMode.Impulse);
            Player.instance.DecreaseSp(25f);

        }
        else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D))
        {
            anit.SetBool("IsRolling_R", false);

        }
    }
}
