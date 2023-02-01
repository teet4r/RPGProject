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
        _wfsInvincibleTime = new WaitForSeconds(_invincibleTime);
        _wfsReturnToPoolTime = new WaitForSeconds(_returnToPoolTime);
    }

    protected virtual void OnEnable()
    {
        CurHp = MaxHp;
        _isInvincible = false;

        _prevPos = transform.position;
        _prevTime = Time.time;
    }

    protected virtual void Update()
    {
        if (!IsAlive) return;
    }



    public void Heal(float healAmount)
    {
        if (!IsAlive) return;

        _Heal(healAmount);
    }

    public void GetDamage(float damageAmount)
    {
        if (IsInvincible) return;

        _GetDamage(damageAmount);
    }



    protected virtual void _Heal(float healAmount)
    {
        SoundManager.Instance.SfxAudio.Play(_healSoundName);
        CurHp = Mathf.Min(CurHp + healAmount, MaxHp);
    }

    protected virtual void _GetDamage(float damageAmount)
    {
        CurHp -= damageAmount;
        if (CurHp <= 0f)
        {
            _Die();
            return;
        }

        SoundManager.Instance.SfxAudio.Play(_getDamageSoundName);
        StartCoroutine(_InvincibleRoutine());
    }

    protected virtual void _Die()
    {
        CurHp = 0f;
        _isInvincible = false;

        StartCoroutine(_DieRoutine());
    }



    /// <summary>
    /// For invincible state
    /// </summary>
    IEnumerator _InvincibleRoutine()
    {
        _isInvincible = true;
        yield return _wfsInvincibleTime;
        _isInvincible = false;
    }

    /// <summary>
    /// For returning to pool
    /// </summary>
    IEnumerator _DieRoutine()
    {
        yield return _wfsReturnToPoolTime;
        PoolManager.Instance.Put(gameObject);
    }



    public bool IsAlive
    {
        get
        {
            return gameObject != null && gameObject.activeInHierarchy && enabled && CurHp > 0f;
        }
    }
    public bool IsWalking
    {
        get
        {
            var _isWalking =
                IsAlive &&
                transform.position - _prevPos != Vector3.zero &&
                Time.time - _prevTime != 0f;
            _prevPos = transform.position;
            _prevTime = Time.time;
            return _isWalking;
        }
    }
    public bool IsInvincible
    {
        get
        {
            if (IsAlive) return _isInvincible;
            return false;
        }
    }
    public float MaxHp
    {
        get
        {
            return _maxHp;
        }
        protected set
        {
            _maxHp = Mathf.Max(value, 1f);
        }
    }
    public float CurHp
    {
        get
        {
            return _curHp;
        }
        protected set
        {
            _curHp = Mathf.Clamp(value, 0f, MaxHp);
        }
    }

    [Header("----- Object Info -----")]
    [Min(1f)][SerializeField] float _maxHp = 50f;
    [Min(0f)][SerializeField] float _invincibleTime = 0.5f;
    [Min(0f)][SerializeField] float _returnToPoolTime = 5f;

    [Header("----- Sounds -----")]
    [SerializeField] string _healSoundName = null;
    [SerializeField] string _getDamageSoundName = null;
    [SerializeField] string _dieSoundName = null;

    WaitForSeconds _wfsInvincibleTime = null;
    WaitForSeconds _wfsReturnToPoolTime = null;
    Vector3 _prevPos;
    float _curHp;
    float _prevTime;
    bool _isInvincible;
}
