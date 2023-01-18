using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    void Awake()
    {
        ValidCheck();
    }
    void OnEnable()
    {
        _attackCollider.isTrigger = true;
    }

    void ValidCheck()
    {
        if (_parent == null)
            throw new System.Exception("Parent is null!");

        if (string.IsNullOrEmpty(_colliderTag))
            throw new System.Exception("Collider Tag is null!");
        else
            tag = _colliderTag;
    }
    
    public Player parent { get { return _parent; } }
    [SerializeField] Player _parent = null;
    [SerializeField] Collider _attackCollider = null;
    [SerializeField] string _colliderTag = null;
}
