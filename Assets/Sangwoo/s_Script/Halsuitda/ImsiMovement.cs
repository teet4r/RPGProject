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

    //콤보시스템
    public float cooldownTime = 2f; //쿨타임
    private float nextFireTime = 0f;
    public static int noOfClicks = 0; //클릭 횟수
    float lastClickTime = 0; //마지막으로 클릭한 횟수
    float maxComboDelay = 1; //콤보

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
    
    void Onclick() //클릭입력과 횟수 정보를 처리해줄 클릭함수
    {
        lastClickTime = Time.time;//time.time 게임시작후 진행시간
        noOfClicks++;
        if(noOfClicks == 1)//클랙했을때!! true면 실행
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
