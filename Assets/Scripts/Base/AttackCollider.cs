using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
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
    /// MonsterObject�� ã�� �Լ�
    /// </summary>
    /// <param name="transform"></param>
    void _FindParent(Transform transform)
    {
        if (transform == null)
            return;
        if (transform.TryGetComponent(out MonsterObject monsterObject))
        {
            _parent = monsterObject;
            return;
        }
        _FindParent(transform.parent);
    }

    public MonsterObject parent { get { return _parent; } }
    [SerializeField] MonsterObject _parent = null;
    [SerializeField] Collider _attackCollider = null;
}
