using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float Height = 4.0f;
    public float Distance = 5f;
    public float moveDamping = 15f; //�̵� ���
    public float rotateDamping = 10f;//ȸ�� ���
    public float targetOffset = 2.0f;//���� ��ǥ�� ������
    private Transform tr;
    private float origiHeight;  //������ ���̸� ����
    private float overDamping = .0f;//�̵� �ӵ� ���


    [Header("Etc Obstacle Setting")]
    public float heightobstacle = 15.0f;  //ī�޶� ��ֹ��� �ε�ĥ�� ī�޶� �ö� ����
    public float playerObstacle = 5.0f; //ī�޶� ��ֹ��� �ε�ĥ�� ī�޶� �Ÿ�
    public float castOffset = 1.0f;//���ΰ��� ������ ����ĳ��Ʈ�� ���� ������





    void Start()
    {
        tr = GetComponent<Transform>();
        origiHeight = Height;

    }



    private void Update()
    {
        //���ΰ� ��ֹ��� ���� �������� �Ǵ��� ����ĳ��Ʈ�� �����̸� ����
        Vector3 castTarget = target.position + (target.up * castOffset);

        //castTarget ��ǥ���� ���� ���͸� ���
        Vector3 castDir = (castTarget - tr.position).normalized;//normalized �� ������ ������ �����ش�.


        RaycastHit hit;
        if (Physics.Raycast(tr.position, castDir, out hit, Mathf.Infinity))// Mathf.Infinity������
        {   //���ΰ��� ����ĳ��Ʈ�� ���� �ʾ�����
            if (!hit.collider.CompareTag("Player"))
            {
                Height = Mathf.Lerp(Height, heightobstacle, Time.deltaTime * overDamping);
                //�����Լ��� �̿��ؼ� ī�޶� ���̸� �ε巴�� ��½�Ŵ

            }
            else
            {
                //���� �Լ��� �̿��ؼ� ī�޶� ���̸� �ε巴�� �ϰ���Ŵ
                Height = Mathf.Lerp(Height, origiHeight, Time.deltaTime * overDamping);
            }
        }


    }

    void LateUpdate()
    {               //ī�޶� ��ġ�� Ÿ�� �ڿ� Ÿ�� ���� ��ġ

        var camPos = target.position - (target.forward * Distance)
                                     + (target.up * Height);
        tr.position = Vector3.Lerp(tr.position, camPos, Time.deltaTime * moveDamping);
        //�����Լ�    ���� Ȥ�� �̵��ϴ� ������ ��ġ�� �����ִ°�
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, Time.deltaTime * rotateDamping);
        //ȸ�� ����
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
