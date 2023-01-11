using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugifySword : MonoBehaviour
{
    public Vector3 targetscale = new Vector3(5,5,5);
    public float hugeSpeed;

    private float time;
    private Vector3 originScale;
    

    private void Awake()
    {
        originScale = transform.localScale; //원래 크기 저장
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha2))
        {
            StartCoroutine(Routine());
        }
    }

   
    
   

   

    IEnumerator Routine()
    {
        // 크기가 커짐
        while (transform.localScale.x < targetscale.x)
        {
            transform.localScale = originScale * (1f + time * hugeSpeed);
            time += Time.deltaTime;

            yield return null;
        }
        time = 0;

        yield return new WaitForSeconds(4f);

        // 크기가 작아짐
        while (transform.localScale.x > originScale.x)
        {
            
            transform.localScale = targetscale / (1f + time * hugeSpeed);
            time += Time.deltaTime;

            yield return null;
        }
        time = 0;
    }
}
        
  

    


