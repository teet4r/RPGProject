using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : LifeObject
{
    //�ۼ��� : �̻��
    //�ۼ��� : 23-01-04 ~
    //public string name { }
    // ü���� curHp. _maxHp�� ����
    float nowMp = 0f;
    float maxMp = 100f;
    float nowExp = 0f;
    float maxExp = 1000f;
    int nowLevel = 1;
    int maxLevel = 10;
    int reviveCoin = 2;
    [SerializeField]
    Vector3 townPosition;

    //���¹̳�
    float nowSp = 0f;
    float maxSp = 100f;
    bool usedSp; //�ൿüũ
    const float increaseSp = 20f; //���¹̳� ������
    const float restoreTimeSP = 1.5f; //���¹̳� ȸ�� ������ �ð� ,ȸ���Ҷ����� �ɸ��� �ð�
    float nowRestoreTimeSP ; // ���¹̳� ���� ȸ���ð�,ȸ���ϴ½ð�

    public float atk = 10f;
    public float atkSpd = 30f;

    [SerializeField]
    Animator animator;

    public float NowMp { get { return nowMp; } }
    public float MaxMp { get { return maxMp; } }

    public float NowExp { get { return nowExp; } }
    public float MaxExp { get { return maxExp; } }

    public float NowLevel { get { return nowLevel; } }
    public float MaxLevel { get { return maxLevel; } }

    public float NowSp { get { return nowSp; } }
    public float MaxSp { get { return maxSp; } }

    public float Atk { get { return atk; } }
    public float AtkSpd { get { return atkSpd; } }

    public static Player instance = null;

    protected override void Awake()
    {
        if (instance == null)
            instance = this;

        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        nowSp = maxSp;
    }
    protected override void Update()
    {
        base.Update();

        Debug.Log(curHp);
    }
    // ���Ϳ� �浹ó��
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AttackCollider attackCollider))
            GetDamage(attackCollider.parent.data.damage);
    }
    // ���Ϳ� �浹ó��
    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out AttackCollider attackCollider))
            GetDamage(attackCollider.parent.data.damage);
    }
    // ���� �������� �浹ó��
    void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out MagicAttack magicAttack))
            GetDamage(magicAttack.damage);
    }

    public void AddHp(float value)
    {
        float _calcHp = curHp + value;
        curHp = Mathf.Min(_calcHp, maxHp);
    }

    public void AddMp(float value)
    {
        nowMp = Mathf.Min(nowMp + value, maxMp);
    }

    void LevelUp()
    {
        while (nowExp >= maxExp)
        {
            nowLevel += 1;
            _maxHp *= 1.1f;
            maxMp *= 1.1f;
            maxExp *= 1.3f;
            atk *= 1.1f;
            curHp = _maxHp;
            nowMp = maxMp;
            nowExp -= maxExp;
        }
    }
    public void AddExp(int value) //����
    {
        nowExp += value;

        LevelUp();
    }
    private void RestoreSP()//���¹̳�
    {
        if (usedSp == false)
        {
            nowSp += increaseSp * Time.deltaTime;
            if (nowSp > maxSp)
            {
                nowSp = maxSp;
            }
        }
    }

    private void RestoreSpDelay() //���¹̳��� �Ҹ�ǰ� ȸ���ð� �����̿� ����. 2
    {
        if (usedSp)
        {
            if (nowRestoreTimeSP < restoreTimeSP)
                nowRestoreTimeSP++;
            else
                usedSp = false;
        }
    }
    public void DecreaseSp(float value_DS) //���¹̳� �Ҹ� 1
    {
        usedSp = true;
        nowRestoreTimeSP = 0;
        if (nowSp - value_DS >= 0)
            nowSp -= value_DS;
        //else
        //    AlertManager.instance.ShowAlert("���¹̳��� �����մϴ�.");
    }
    public void Revive()
    {
        curHp = reviveCoin-- * maxHp * 0.5f;
        animator.SetTrigger("IsRevive");
    }

    public void RefillRevive()
    {
        reviveCoin = 2;
    }
    public void MoveToTown()
    {
        transform.position = townPosition;
        RefillRevive();
    }
    //void nParticleTrigger()
    //{
        
    //}
    
    protected override IEnumerator _TriggerGetDamage(float damage)
    {
        isInvincible = true;

        curHp -= damage;
        if (curHp <= 0f)
            _Die();
        else
            animator.SetTrigger("IsGetHit");

        yield return _wfs_invincible;
        isInvincible = false;
    }
    protected override void _Die()
    {
        base._Die();

        StartCoroutine(_DieRoutine()); // �׾��� �� ������ �ڷ�ƾ
    }

    // �� �̷��� ��������?
    // IsDie �ִϸ��̼��� ����Ǵ� �ð��� ���� ����.
    // ���� yield�� ���� ���� ��.
    IEnumerator _DieRoutine()
    {
        animator.SetTrigger("IsDie"); // 0.5�ʰ� ������ �Ǵ���
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}