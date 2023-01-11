using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPattern1 : MonoBehaviour, IAttackPattern
{
    public void Attack(LifeObject parent, Transform targetTransform)
    {
        if (!parent.isAlive || targetTransform == null) return;
    }
}
