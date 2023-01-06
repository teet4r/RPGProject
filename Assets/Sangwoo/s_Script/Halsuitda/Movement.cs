using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
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

    public float smoothBlend = 0.1f; //애니메이션 time.deltatime랑 같이 쓰면 빠르고 부드러워짐
    public float moveSpeed = 3.5f;  //움직일떄 속도
    public float turnSpeed = 90f;
    public float rollSpeed = 60f; //구르기 속도

    public bool IsSprint;   //달리기는 속도에 +=해주기
    
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
        //정면
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
        //후면
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
        //왼쪽
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
       //오른쪽
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
