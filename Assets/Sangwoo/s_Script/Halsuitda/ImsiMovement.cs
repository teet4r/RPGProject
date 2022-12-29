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

    float h, v, r; //vectpr값을 저장하기 위해서 (h=호라이즌,v=버티컬,r=잘모르겠음) 

    public float smoothBlend = 0.1f; //애니메이션 time.deltatime랑 같이 쓰면 빠르고 부드러워짐
    public float moveSpeed = 3.5f;  //움직일떄 속도
    public float turnSpeed = 90f;
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
