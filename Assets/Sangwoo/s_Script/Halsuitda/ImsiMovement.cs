using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImsiMovement : MonoBehaviour
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

    float Rollh, Rollv, Rollr; //�Ѹ��� �̵��� ���� blendtree ���

    public float smoothBlend = 0.1f; //�ִϸ��̼� time.deltatime�� ���� ���� ������ �ε巯����
    public float moveSpeed = 3.5f;  //�����ϋ� �ӵ�
    public float turnSpeed = 90f;
    public float rollSpeed; //������ �ӵ�

    public bool IsSprint;   //�޸���� �ӵ��� +=���ֱ�
   



   // public static int noOfClicks = 


    //private readonly int hashRoll = Animator.StringToHash("Roll");
    //int jumpHash = Animator.StringToHash("Roll");


    
    void Start()
    {
        tr = GetComponent<Transform>();
        anit = GetComponent<Animator>();
    }

    
    void Update()
    {
        Move();
        Attack();
        
       
       
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





        //Roll2();
    }

    void Roll()
    {
        //�귣�� Ʈ�� ����
        
            anit.SetTrigger("IsRolling");
            {
                Rollh = Input.GetAxis("Horizontal");
                Rollv = Input.GetAxis("Vertical");
                Rollr = Input.GetAxis("Mouse X");


                tr.Translate(Vector3.right * Rollh * rollSpeed * Time.deltaTime);
                {
                   
                    anit.SetFloat("SpeedX", Rollh, smoothBlend, Time.deltaTime);

                }
                tr.Translate(Vector3.forward.normalized * Rollv * rollSpeed * Time.deltaTime);
                {
                    anit.SetFloat("SpeedY", Rollv, smoothBlend, Time.deltaTime);

                }
                tr.Rotate(Vector3.up * Rollr * Time.deltaTime * turnSpeed);
            }



        




    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            moveSpeed = 7f;
            anit.SetBool("IsSprint", true);
            Roll2();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W))
        {
            moveSpeed = 3.5f;
            anit.SetBool("IsSprint", false);

        }
    }

    void Roll2()
    {
       if(Input.GetKey(KeyCode.Space)&&Input.GetKey(KeyCode.A))
       {
            anit.SetBool("IsRolling_L", true);

       }
       else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.A))
       {
            anit.SetBool("IsRolling_L", false);

       }

        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.D))
        {
            anit.SetBool("IsRolling_R", true);

        }
        else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D))
        {
            anit.SetBool("IsRolling_R", false);

        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anit.SetTrigger("IsAttack"); 
        }
        
    }
    

   


}
