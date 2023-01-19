using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMagePattern1 : MonoBehaviour, IAttackPattern
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

        for (int i = 0; parent.IsAlive && targetTransform != null && i < _explosionCount; i++)
        {
            var newMyEuler = new Vector3(_magicAttackPrefab.transform.eulerAngles.x, Random.Range(0f, 360f), _magicAttackPrefab.transform.eulerAngles.z);
            yield return _attackRate;
            if (!parent.IsAlive || targetTransform == null) yield break;
            var clone = Instantiate(_magicAttackPrefab, targetTransform.position, _magicAttackPrefab.transform.rotation);
            clone.transform.eulerAngles = newMyEuler;
        }
    }

    [SerializeField] GameObject _magicAttackPrefab;
    [SerializeField] int _explosionCount = 5;
    WaitForSeconds _effectDelayTime = new WaitForSeconds(0.5f);
    WaitForSeconds _attackRate = new WaitForSeconds(0.3f);
}
