using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTransform : MonoBehaviour
{

    float time = 0;
    public float _size =5;
    public float _upSizetime = 0.2f;
    public Vector3 size;
    void Start()
    {
        size = transform.localScale;
    }
    void Update()
    {
        Transform();
    }
       
        
    
    public void resetAnim()
    {
        time = 0;
    }

    void Transform()
    {

        //while (Input.GetKey(KeyCode.Alpha2))
        //{
        //    if (time <= _upSizetime)
        //    {
        //        transform.localScale = Vector3.one * (1 + _size * time);

        //    }
        //    //else if (time <= _upSizetime * 2)
        //    //{
        //    //    transform.localScale = Vector3.one * (2 * _size * _upSizetime + 1 - time * _size);
        //    //}
        //    else
        //    {
        //        transform.localScale = Vector3.one;
        //    }
        //    time += Time.deltaTime;

        //}


    }
    


}
