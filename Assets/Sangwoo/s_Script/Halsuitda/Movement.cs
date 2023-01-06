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
   
    float h, v, r; //vectpr���� �����ϱ� ���ؼ� (h=ȣ������,v=��Ƽ��,r=���콺ȣ������(ȸ��)) (�̵�)

    public float smoothBlend = 0.1f; //�ִϸ��̼� time.deltatime�� ���� ���� ������ �ε巯����
    public float moveSpeed = 3.5f;  //�����ϋ� �ӵ�
    public float turnSpeed = 90f;
    public float rollSpeed = 60f; //������ �ӵ�

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
            moveSpeed += 3.5f;
            anit.SetBool("IsSprint", true);
            Roll();
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
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W))
        {
            anit.SetBool("IsRolling_F", true);
            tr.Translate(Vector3.forward * rollSpeed * Time.deltaTime);
            // tr.Translate(Vector3.right + 10 * Rollh * rollSpeed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            anit.SetBool("IsRolling_F", false);


        }
        //�ĸ�
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {
            anit.SetBool("IsRolling_B", true);
            // tr.Translate(Vector3.right + 10 * Rollh * rollSpeed * Time.deltaTime);
            tr.Translate(Vector3.back * rollSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.S))
        {
            anit.SetBool("IsRolling_B", false);

        }
        //����
        if (Input.GetKey(KeyCode.Space)&&Input.GetKey(KeyCode.A))
       {
            anit.SetBool("IsRolling_L", true);
            // tr.Translate(Vector3.right + 10 * Rollh * rollSpeed * Time.deltaTime);
            tr.Translate(Vector3.left * rollSpeed * Time.deltaTime);
        }
       else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.A))
       {
            anit.SetBool("IsRolling_L", false);

       }
       //������
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.D))
        {
            anit.SetBool("IsRolling_R", true);
            tr.Translate(Vector3.right * rollSpeed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D))
        {
            anit.SetBool("IsRolling_R", false);

        }
    }
}
