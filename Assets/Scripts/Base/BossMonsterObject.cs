using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonsterObject�� ����ϴ� ���� Ŭ����
/// </summary>
[RequireComponent(typeof(Rotate3D))]
public abstract class BossMonsterObject : MonsterObject
{
    protected Rotate3D _rotate3D = null;

    protected override void Awake()
    {
        base.Awake();

        _rotate3D = GetComponent<Rotate3D>();
    }
}
