using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour를 상속하는 최상위 클래스이며
/// 생명체에 기본 적용되는 클래스
/// </summary>
public abstract class LifeObject : MonoBehaviour
{
    protected virtual void Awake()
    {
        _wfs_invincible = new WaitForSeconds(_invincibleTime);
    }
    protected virtual void OnEnable()
    {
        isInvincible = false;
        curHp = maxHp;

        _prevPos = transform.position;
        _prevTime = Time.time;
    }

    public virtual void Heal(float healAmount)
    {
        if (!isAlive) return;

        curHp = Mathf.Min(curHp + healAmount, maxHp);
    }
    public virtual void GetDamage(float damageAmount)
    {
        if (!isAlive) return;
        if (isInvincible) return;

        StartCoroutine(_TriggerGetDamage(damageAmount));
    }
    protected virtual void _Die()
    {
        if (!isAlive) return;

        curHp = 0f;
        isInvincible = false;
    }
    protected abstract IEnumerator _TriggerGetDamage(float damage);

    public bool isAlive
    {
        get
        {
            return gameObject != null && gameObject.activeInHierarchy && enabled && curHp > 0f;
        }
    }
    public bool isWalking
    {
        get
        {
            var _isWalking =
                isAlive &&
                transform.position - _prevPos != Vector3.zero &&
                Time.time - _prevTime != 0f;
            _prevPos = transform.position;
            _prevTime = Time.time;
            return _isWalking;
        }
    }
    public bool isInvincible { get; protected set; }
    public float maxHp { get { return _maxHp; } }
    public float curHp { get; protected set; }
    protected WaitForSeconds _wfs_invincible = null;
    [SerializeField] protected float _maxHp = 50f;
    [Tooltip("피격 후 무적 시간")]
    [SerializeField] float _invincibleTime = 0.5f;
    Vector3 _prevPos;
    float _prevTime;
}
