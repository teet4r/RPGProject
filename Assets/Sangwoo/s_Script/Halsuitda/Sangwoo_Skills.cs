using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sangwoo_Skills : MonoBehaviour
{

    public float scale = 5f;
    public float hugeSpeed;
    private float time;
    private Vector3 originScale;

    void Awake()
    {
        
    }
    void Update()
    {
        Skill2();
       
    }
    private void OnEnable()
    {
        
    }

    void Skill2()
    {
        originScale = transform.localScale; //원래 크기 저장
        gameObject.transform.localScale = originScale;
        
    }
}
