using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMagePattern2 : MonoBehaviour, IAttackPattern
{
    public void Attack(LifeObject parent, Transform targetTransform)
    {
        if (targetTransform == null) return;

        StartCoroutine(_Attack(targetTransform));
    }

    IEnumerator _Attack(Transform targetTransform)
    {
        if (targetTransform == null) yield break;

        yield return _effectDelayTime;
        for (int i = 0; i < _FlameCount; i++)
        {
            yield return _attackRate;
            Instantiate(_magicAttackPrefab, targetTransform.position, _magicAttackPrefab.transform.rotation);
        }
    }

    [SerializeField] GameObject _magicAttackPrefab;
    [SerializeField] int _FlameCount = 1;
    WaitForSeconds _effectDelayTime = new WaitForSeconds(0.5f);
    WaitForSeconds _attackRate = new WaitForSeconds(0.15f);
}
