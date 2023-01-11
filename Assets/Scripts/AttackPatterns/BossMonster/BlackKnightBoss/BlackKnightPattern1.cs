using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnightPattern1 : MonoBehaviour, IAttackPattern
{
    public void Attack(LifeObject parent, Transform targetTransform)
    {
        if (!parent.isAlive || targetTransform == null) return;

        StartCoroutine(_Attack(parent, targetTransform));
    }

    IEnumerator _Attack(LifeObject parent, Transform targetTransform)
    {
        yield return _effectDelayTime;
        if (!parent.isAlive || targetTransform == null) yield break;
        var targetPosition = targetTransform.position;
        targetPosition.x = 0f;
        targetPosition.y = 0f;
        targetPosition.z = 2.8f;
        var newTargetPos = transform.TransformPoint(targetPosition);
        for (int i = 0; parent.isAlive && targetTransform != null && i < _smashCount; i++)
        {
            Instantiate(_magicAttackPrefab, newTargetPos, _magicAttackPrefab.transform.rotation);
            yield return _attackRate;
        }
    }

    [SerializeField] GameObject _magicAttackPrefab;
    [SerializeField] int _smashCount = 1;
    WaitForSeconds _effectDelayTime = new WaitForSeconds(0.85f);
    WaitForSeconds _attackRate = new WaitForSeconds(0.15f);
}
