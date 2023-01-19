using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPattern2 : MonoBehaviour, IAttackPattern
{
    public void Attack(LifeObject parent, Transform targetTransform)
    {
        if (!parent.IsAlive || targetTransform == null) return;

        StartCoroutine(_Attack(parent, targetTransform));
    }

    IEnumerator _Attack(LifeObject parent, Transform targetTransform)
    {
        yield return _effectDelayTime;
        if (!parent.IsAlive || targetTransform == null) yield break;
        
        for (int i = 0; parent.IsAlive && targetTransform != null && i < _fireBreathCount; i++)
        {
            Instantiate(_magicAttackPrefab, transform);
            yield return _attackRate;
        }
    }

    [SerializeField] GameObject _magicAttackPrefab;
    [SerializeField] int _fireBreathCount = 1;
    WaitForSeconds _effectDelayTime = new WaitForSeconds(0.75f);
    WaitForSeconds _attackRate = new WaitForSeconds(0.15f);
}
