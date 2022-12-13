using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagicMovement : MonoBehaviour
{
   
    private Animator animator;
    public float speed;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
   

   
    private void Update()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");

        animator.SetFloat("MoveX", MoveX);
        animator.SetFloat("MoveY", MoveY);
    }
}
