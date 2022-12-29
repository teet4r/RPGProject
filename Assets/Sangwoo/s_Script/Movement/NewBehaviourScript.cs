using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
    Idle,
    Move,
};



public class NewBehaviourScript : MonoBehaviour
{
    public State currentState = State.Idle;
    
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
         
    }

    void ChangeState(State newState,int aniNumber)
    {
        if(currentState == newState)
        {
            return;
        }

        //anim.SetInteger();
    }

    void CheckClick()//클릭이동
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.gameObject.tag == "Ground")
                {
                    transform.position = hit.point;
                }
            }
        }
    }


    //public void MoveTo(Vector3 tPos)
    //{
    //    curTargetPos = tPos;
    //}


    //void ChangeState(StateMachineBehaviour )

    //void Update()
    //{
    //    CheckClick();
    //}
}
