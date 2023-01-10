using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float rot_speed = 100.0f;

    public GameObject Player;
    public GameObject MainCamera;

    private float camera_dist = 0f; //���׷κ��� ī�޶������ �Ÿ�
    public float camera_width = -10f; //���ΰŸ�
    public float camera_height = 4f; //���ΰŸ�
    public float camera_fix = 3f;//�����ɽ�Ʈ �� ���������� �� �Ÿ�

    Vector3 dir;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //ī�޶󸮱׿��� ī�޶������ ����
        camera_dist = Mathf.Sqrt(camera_width * camera_width + camera_height * camera_height);

        //ī�޶󸮱׿��� ī�޶���ġ������ ���⺤��
        dir = new Vector3(0, camera_height, camera_width).normalized;

    }


    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rot_speed, Space.World);

        transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * Time.deltaTime * rot_speed, Space.Self);

        transform.position = Player.transform.position;


        //����ĳ��Ʈ�� ���Ͱ�
        Vector3 ray_target = transform.up * camera_height + transform.forward * camera_width;
        Debug.Log("ray_target : " + ray_target);

        RaycastHit hitinfo;
        Physics.Raycast(transform.position, ray_target, out hitinfo, camera_dist);

        if (hitinfo.point != Vector3.zero)//�����ɽ�Ʈ ������
        {
            //point�� �ű��.
            MainCamera.transform.position = hitinfo.point;
            //ī�޶� ����
            MainCamera.transform.Translate(dir * -1 * camera_fix);
        }
        else
        {
            //������ǥ�� 0���� �����. (ī�޶󸮱׷� �ű��.)
            MainCamera.transform.localPosition = Vector3.zero;
            //ī�޶���ġ������ ���⺤�� * ī�޶� �ִ�Ÿ� �� �ű��.
            MainCamera.transform.Translate(dir * camera_dist);
            //ī�޶� ����
            MainCamera.transform.Translate(dir * -1 * camera_fix);

        }
    }
}
