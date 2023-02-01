using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody = null;
    [SerializeField] float _addUpwardForce = 10f;

    void Start()
    {
        _rigidbody.AddForce(transform.up * _addUpwardForce);
    }
}
