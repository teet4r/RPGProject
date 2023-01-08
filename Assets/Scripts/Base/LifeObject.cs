using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour�� ����ϴ� �ֻ��� Ŭ�����̸�
/// ����ü�� �⺻ ����Ǵ� Ŭ����
/// </summary>
public abstract class LifeObject : MonoBehaviour
{
    protected virtual void Awake()
    {
        _wfs_invincible = new WaitForSeconds(_invincibleTime);
    }
    protected virtual void OnEnable()
    {
        isAlive = true;
        isWalking = false;
        isInvincible = false;
        curHp = maxHp;

        _prevPos = transform.position;
    }
    protected virtual void Update()
    {
        if (!isAlive) return;

        _UpdateStates();
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

        isAlive = false;
        isWalking = false;
        isInvincible = false;

        curHp = 0f;
    }
    protected virtual void _UpdateStates()
    {
        isWalking = transform.position - _prevPos == Vector3.zero ? false : true;
        _prevPos = transform.position;
    }
    protected abstract IEnumerator _TriggerGetDamage(float damage);

    public bool isAlive { get; private set; }
    public bool isWalking { get; private set; }
    public bool isInvincible { get; protected set; }
    public float maxHp { get { return _maxHp; } }
    public float curHp { get; protected set; }
    protected WaitForSeconds _wfs_invincible = null;
    [SerializeField] protected float _maxHp = 50f;
    [Tooltip("�ǰ� �� ���� �ð�")]
    [SerializeField] float _invincibleTime = 0.5f;
    Vector3 _prevPos;
}
