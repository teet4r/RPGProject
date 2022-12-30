using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImsiMovement : MonoBehaviour
{

    //작성자: 이상우
    //작성일: 22-12-29

    //public float InputX;
    //public float InputY;

    
    [SerializeField] //자기자신 위치 (컴포넌트)불러올때 저장소
    Transform tr;
    [SerializeField] //에니메이터 (컴포넌트)불러올떄 저장소
    Animator anit;

    float h, v, r; //vectpr값을 저장하기 위해서 (h=호라이즌,v=버티컬,r=마우스호라이즌(회전)) (이동)

    float Rollh, Rollv, Rollr; //롤링도 이동과 같이 blendtree 사용

    public float smoothBlend = 0.1f; //애니메이션 time.deltatime랑 같이 쓰면 빠르고 부드러워짐
    public float moveSpeed = 3.5f;  //움직일떄 속도
    public float turnSpeed = 90f;
    public float rollSpeed; //구르기 속도

    public bool IsSprint;   //달리기는 속도에 +=해주기
   



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
        //브랜드 트리 실험
        
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
