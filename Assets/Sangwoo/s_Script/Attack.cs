using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        _comboState = 0;
    }
    void Update()
    {
        var curAnimatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (curAnimatorStateInfo.IsTag("Attack")) // 공격 중이라면
        {
            // 검에 있는 콜라이더 활성화
            _weaponCollider.enabled = true;
        }
        else // 아니라면
        {
            // 검에 있는 콜라이더 비활성화
            _weaponCollider.enabled = false;
        }
        
        if (curAnimatorStateInfo.tagHash.CompareTo(_attackTag) != 0)
            _comboState = 0;
        if (_comboState >= _attackStates.Length)
            _comboState = 0;

        if (Input.GetMouseButtonDown(0))
        {
            if (_comboState == 0)
            {
                _animator.SetTrigger(_attackStates[_comboState]);
                _comboState++;
            }
            else if (_comboState >= 1)
                if (curAnimatorStateInfo.shortNameHash.CompareTo(_attackStates[_comboState - 1]) == 0)
                {
                    _animator.SetTrigger(_attackStates[_comboState]);
                    _comboState++;
                }
        }
    }

    public bool isAttacking { get; private set; } = false;
    [SerializeField] Collider _weaponCollider;
    Animator _animator;
    int _comboState;
    int[] _attackStates =
    {
        Animator.StringToHash("Attack0"),
        Animator.StringToHash("Attack1"),
        Animator.StringToHash("Attack2"),
        Animator.StringToHash("Attack3")
    };

    readonly int _attackTag = Animator.StringToHash("Attack");
}
