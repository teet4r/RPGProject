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

    float h, v, r; //vectpr���� �����ϱ� ���ؼ� (h=ȣ������,v=��Ƽ��,r=�߸𸣰���) 

    public float smoothBlend = 0.1f; //�ִϸ��̼� time.deltatime�� ���� ���� ������ �ε巯����
    public float moveSpeed = 3.5f;  //�����ϋ� �ӵ�
    public float turnSpeed = 90f;
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

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            moveSpeed = 7f;
            anit.SetBool("IsSprint", true);

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W))
        {
            moveSpeed = 3.5f;
            anit.SetBool("IsSprint", false);

        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anit.SetTrigger("IsAttack"); 
        }
    }
    

    void Roll()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            
        }
    }


}
