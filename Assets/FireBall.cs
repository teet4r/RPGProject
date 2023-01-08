using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Rigidbody m_rigid = null;
    Transform m_ttTarget = null;

    [SerializeField] float m_speed = 0f;
    float m_currentSpeed = 0f;
    [SerializeField] LayerMask m_layerMask = 0;
    [SerializeField] ParticleSystem m_psEffect = null;

    void SearchEnemy()
    {
        Collider[] t_cols = Physics.OverlapSphere(transform.position, 100f, 1 << 14);

        if (t_cols.Length > 0)
        {
            m_ttTarget = t_cols[Random.Range(0, t_cols.Length)].transform;
        }

    }

    IEnumerator LanuchDelay()
    {
        yield return new WaitUntil(() => m_rigid.velocity.y < 0f);
        yield return new WaitForSeconds(0.1f);

        SearchEnemy();
        m_psEffect.Play();

        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        StartCoroutine(LanuchDelay());
    }

    void Update()
    {
        if(m_ttTarget != null)
        {
            if (m_currentSpeed <= m_speed)
                m_currentSpeed += m_speed * Time.deltaTime;

            transform.position += transform.up * m_currentSpeed * Time.deltaTime;

            Vector3 t_dir = (m_ttTarget.position - transform.position).normalized; // 단위벡터(내 위치에서 타겟을 바라보는)
            transform.up = Vector3.Lerp(transform.up, t_dir, 0.25f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.transform.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
