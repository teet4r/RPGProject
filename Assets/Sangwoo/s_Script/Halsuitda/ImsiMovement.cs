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

    //�޺��ý���
    public float cooldownTime = 2f; //��Ÿ��
    private float nextFireTime = 0f;
    public static int noOfClicks = 0; //Ŭ�� Ƚ��
    float lastClickTime = 0; //���������� Ŭ���� Ƚ��
    float maxComboDelay = 1; //�޺�

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
        //Attack();
        Combo();
        Roll2();
       
    }
    void Combo()
    {
        if (anit.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
            anit.GetCurrentAnimatorStateInfo(0).IsName("Combo1"))
        {
            anit.SetBool("Combo1", true);
        }
        if (anit.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
            anit.GetCurrentAnimatorStateInfo(0).IsName("Combo2"))
        {
            anit.SetBool("Combo2", true);
        }
        if (anit.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
            anit.GetCurrentAnimatorStateInfo(0).IsName("Combo3"))
        {
            anit.SetBool("Combo3", false);
        }
        if (anit.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
            anit.GetCurrentAnimatorStateInfo(0).IsName("Combo4"))
        {
            anit.SetBool("Combo4", false);
        }
        if (anit.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
            anit.GetCurrentAnimatorStateInfo(0).IsName("Combo5"))
        {
            anit.SetBool("Combo5", false);
            noOfClicks = 0;
        }

        if (Time.time - lastClickTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Onclick();
            }
        }
    }
    
    void Onclick() //Ŭ���Է°� Ƚ�� ������ ó������ Ŭ���Լ�
    {
        lastClickTime = Time.time;//time.time ���ӽ����� ����ð�
        noOfClicks++;
        if(noOfClicks == 1)//Ŭ��������!! true�� ����
        {
            anit.SetBool("Combo1", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 5);

        if(noOfClicks >= 2 && anit.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && 
            anit.GetCurrentAnimatorStateInfo(0).IsName("Combo1"))
        {
            anit.SetBool("Combo1", false);
            anit.SetBool("Combo2", true);
        }

        if (noOfClicks >= 3 && anit.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
           anit.GetCurrentAnimatorStateInfo(0).IsName("Combo2"))
        {
            anit.SetBool("Combo2", false);
            anit.SetBool("Combo3", true);
        }

        if (noOfClicks >= 4 && anit.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
           anit.GetCurrentAnimatorStateInfo(0).IsName("Combo3"))
        {
            anit.SetBool("Combo3", false);
            anit.SetBool("Combo4", true);
        }

        if (noOfClicks >= 5 && anit.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
           anit.GetCurrentAnimatorStateInfo(0).IsName("Combo4"))
        {
            anit.SetBool("Combo4", false);
            anit.SetBool("Combo5", true);
        }

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
           // tr.Translate(Vector3.right + 10 * Rollh * rollSpeed * Time.deltaTime);

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
