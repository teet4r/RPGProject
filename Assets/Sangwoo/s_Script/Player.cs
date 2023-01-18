using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.AI;
using UnityEditor;

public class Player : LifeObject
{
    float nowMp = 100f;
    float maxMp = 100f;
    float nowExp = 0f;
    float maxExp = 1000f;
    int nowLevel = 1;
    int maxLevel = 10;
    int reviveCoin = 2;
    [SerializeField]
    Vector3 townPosition;

    //���¹̳�
    float nowSp = 100f;
    float maxSp = 100f;
    bool usedSp; //�ൿüũ
    const float increaseSp = 20f; //���¹̳� ������
    const float restoreTimeSP = 1.5f; //���¹̳� ȸ�� ������ �ð� ,ȸ���Ҷ����� �ɸ��� �ð�
    float nowRestoreTimeSP ; // ���¹̳� ���� ȸ���ð�,ȸ���ϴ½ð�

    [SerializeField] float _bodyAtk = 10f;
    [SerializeField] float _weaponAtk = 100f;
    [SerializeField] Collider _bodyCollider = null;

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

    public float BodyAtk { get { return _bodyAtk; } }
    public float WeaponAtk { get { return _weaponAtk; } }

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
    // ���Ϳ� �浹ó��
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AttackCollider attackCollider) && attackCollider.parent.isAlive)
            attackCollider.parent.GetDamage(BodyAtk);
    }
    // ���Ϳ� �浹ó��
    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out AttackCollider attackCollider) && attackCollider.parent.isAlive)
            attackCollider.parent.GetDamage(BodyAtk);
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
            _bodyAtk *= 1.1f;
            _weaponAtk *= 1.1f;
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

    protected sealed override void _Die()
    {
        StartCoroutine(_LateDie());
    }

    IEnumerator _LateDie()
    {
        SoundManager.instance.sfxPlayer.Play(Sfx.PlayerDead);
        animator.SetTrigger("IsDie");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    protected override void _LateGetDamage()
    {
        
    }
}