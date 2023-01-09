using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLuncher : MonoBehaviour
{
   
    
    [SerializeField] GameObject m_goMissile = null;
    [SerializeField] Transform m_ttMissileSpawn = null;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GameObject t_missile = Instantiate(m_goMissile, m_ttMissileSpawn.position, Quaternion.identity);
            t_missile.GetComponent<Rigidbody>().velocity = Vector3.up * 5f;
        }
    }
}
