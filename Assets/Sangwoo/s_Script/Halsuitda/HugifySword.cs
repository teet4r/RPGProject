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
        originScale = transform.localScale; //���� ũ�� ����
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
        // ũ�Ⱑ Ŀ��
        while (transform.localScale.x < targetscale.x)
        {
            transform.localScale = originScale * (1f + time * hugeSpeed);
            time += Time.deltaTime;

            yield return null;
        }
        time = 0;

        yield return new WaitForSeconds(4f);

        // ũ�Ⱑ �۾���
        while (transform.localScale.x > originScale.x)
        {
            
            transform.localScale = targetscale / (1f + time * hugeSpeed);
            time += Time.deltaTime;

            yield return null;
        }
        time = 0;
    }
}
        
  

    


