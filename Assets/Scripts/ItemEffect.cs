using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody.AddForce(transform.up * 20f);
    }
}
