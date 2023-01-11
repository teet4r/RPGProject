using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [Min(0f)][SerializeField] float _destroyTime = 10f;

    void Start()
    {
        _rigidbody.AddForce(transform.up * 20f);

        Invoke("_Destroy", _destroyTime);
    }

    void _Destroy()
    {
        Destroy(gameObject);
    }
}
