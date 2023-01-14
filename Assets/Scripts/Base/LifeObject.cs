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
        _wfsInvincible = new WaitForSeconds(_invincibleTime);
    }
    protected virtual void OnEnable()
    {
        curHp = maxHp;
        _isInvincible = false;

        _prevPos = transform.position;
        _prevTime = Time.time;
    }

    public virtual void Heal(float healAmount)
    {
        if (!isAlive) return;

        curHp = Mathf.Min(curHp + healAmount, maxHp);
    }
    public void GetDamage(float damageAmount)
    {
        if (isInvincible) return;

        curHp -= damageAmount;
        if (curHp <= 0f)
        {
            curHp = 0f;
            _Die();
            return;
        }
        else
            _LateGetDamage();

        StartCoroutine(_InvincibleRoutine());
    }
    
    protected abstract void _Die();

    /// <summary>
    /// For animations or sounds
    /// </summary>
    protected abstract void _LateGetDamage();


    /// <summary>
    /// For invincible state
    /// </summary>
    /// <returns></returns>
    IEnumerator _InvincibleRoutine()
    {
        _isInvincible = true;
        yield return _wfsInvincible;
        _isInvincible = false;
    }


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
    public bool isInvincible
    {
        get
        {
            if (isAlive) return _isInvincible;
            return false;
        }
    }
    public float maxHp { get { return _maxHp; } }
    public float curHp { get; protected set; }
    protected WaitForSeconds _wfsInvincible = null;
    [SerializeField] protected float _maxHp = 50f;
    [Tooltip("피격 후 무적 시간")]
    [SerializeField] float _invincibleTime = 0.5f;
    Vector3 _prevPos;
    float _prevTime;
    bool _isInvincible;
}
