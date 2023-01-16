using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    void Awake()
    {
        if (_parent == null)
            _FindParent(transform);
    }
    void OnEnable()
    {
        _attackCollider.isTrigger = true;
    }
    
    /// <summary>
    /// Player를 찾는 함수
    /// </summary>
    /// <param name="transform"></param>
    void _FindParent(Transform transform)
    {
        if (transform == null)
            return;
        if (transform.TryGetComponent(out Player player))
        {
            _parent = player;
            return;
        }
        _FindParent(transform.parent);
    }

    public Player parent { get { return _parent; } }
    [SerializeField] Player _parent = null;
    [SerializeField] Collider _attackCollider = null;
}
