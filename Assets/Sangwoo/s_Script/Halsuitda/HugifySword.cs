using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugifySword : MonoBehaviour
{
    public float scale = 5f;
    public float hugeSpeed;

    private float time;
    private Vector3 originScale;

    private void Awake()
    {
        originScale = transform.localScale; //원래 크기 저장
    }
    private void OnEnable()
    {

        StartCoroutine(Up());

    }
    IEnumerator Up()
    {
        while (transform.localScale.x < scale)
        {
            transform.localScale = originScale * (1f + time * hugeSpeed);
            time += Time.deltaTime;

            if (transform.localScale.x >= scale)
            {
                time = 0;
                break;
            }
            yield return null;
        }
    }
   
}
