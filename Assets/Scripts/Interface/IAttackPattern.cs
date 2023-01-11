using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackPattern
{
    void Attack(LifeObject parent, Transform targetTransform);
}
