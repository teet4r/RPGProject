//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Cinemachine;

//public class BagicMovement : MonoBehaviour
//{
//    Rigidbody Rigid;
//    Vector3 Movement;
//    private Animator animator;
//    public float Speed;
//    public float rotateSpeed;
//    float h, v;
//    float lastAttackTime = 0f;
    
   
    


//    private void Awake()
//    {
//        animator = GetComponent<Animator>();
//        Rigid = GetComponent<Rigidbody>();
//    }
   

   
//    void Update()
//    {
//        //�ִϸ�
//        Move();

//    }

   

//    void Move()
//    {
//        //�ִϸ�
//        h = Input.GetAxis("Horizontal");
//        v = Input.GetAxis("Vertical");

//        animator.SetFloat("MoveX", h);
//        animator.SetFloat("MoveY", v);

//        transform.position += new Vector3(h, 0, v) * Speed * Time.deltaTime;


//        //ĳ���� �� ����
//        Vector3 dir = new Vector3(h, 0, v);

//        if(!(h == 0 && v == 0))
//        {
//            transform.position += dir * Speed * Time.deltaTime;
//            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
//        }

//        //Movement.Set(h, 0, v);
//       // Movement = Movement.normalized * speed * Time.deltaTime;


//        //rigidbody.MovePosition(transform.position + Movement);
//    }

//    //private void OnAnimatorMove() ����?
  
//}
