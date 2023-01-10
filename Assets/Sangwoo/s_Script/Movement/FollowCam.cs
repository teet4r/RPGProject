using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float Height = 4.0f;
    public float Distance = 5f;
    public float moveDamping = 15f; //이동 계수
    public float rotateDamping = 10f;//회전 계수
    public float targetOffset = 2.0f;//추적 좌표의 오프셋
    private Transform tr;
    private float origiHeight;  //최초의 높이를 저장
    private float overDamping = .0f;//이동 속도 계수


    [Header("Etc Obstacle Setting")]
    public float heightobstacle = 15.0f;  //카메라가 장애물에 부딪칠때 카메라가 올라갈 높이
    public float playerObstacle = 5.0f; //카메라가 장애물에 부딪칠때 카메라 거리
    public float castOffset = 1.0f;//주인공에 투사할 레이캐스트의 높이 오프셋





    void Start()
    {
        tr = GetComponent<Transform>();
        origiHeight = Height;

    }



    private void Update()
    {
        //주인공 장애물에 가려 졌는지를 판단할 레이캐스트의 높낮이를 설정
        Vector3 castTarget = target.position + (target.up * castOffset);

        //castTarget 좌표로의 방향 벡터를 계산
        Vector3 castDir = (castTarget - tr.position).normalized;//normalized 를 넣으면 방향을 보여준다.


        RaycastHit hit;
        if (Physics.Raycast(tr.position, castDir, out hit, Mathf.Infinity))// Mathf.Infinity무제한
        {   //주인공이 레이캐스트에 맞지 않았을떄
            if (!hit.collider.CompareTag("Player"))
            {
                Height = Mathf.Lerp(Height, heightobstacle, Time.deltaTime * overDamping);
                //보간함수를 이용해서 카메라 높이를 부드럽게 상승시킴

            }
            else
            {
                //보간 함수를 이용해서 카메라 높이를 부드럽게 하강시킴
                Height = Mathf.Lerp(Height, origiHeight, Time.deltaTime * overDamping);
            }
        }


    }

    void LateUpdate()
    {               //카메라 위치를 타겟 뒤에 타겟 위에 배치

        var camPos = target.position - (target.forward * Distance)
                                     + (target.up * Height);
        tr.position = Vector3.Lerp(tr.position, camPos, Time.deltaTime * moveDamping);
        //보간함수    직선 혹은 이동하는 과정을 수치로 보여주는것
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, Time.deltaTime * rotateDamping);
        //회전 보간
        tr.LookAt(target.position + (target.forward*-1 * targetOffset));


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(target.position + (target.up * targetOffset), 1.0f);
        Gizmos.DrawLine(target.position + (target.up * targetOffset), transform.position);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1f);

    }
}
