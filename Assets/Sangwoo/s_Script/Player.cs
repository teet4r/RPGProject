using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : LifeObject
{
    //작성자 : 이상우
    //작성일 : 23-01-04 ~
    //public string name { }
    // 체력은 curHp. _maxHp로 접근
    float nowMp = 0f;
    float maxMp = 100f;
    float nowExp = 0f;
    float maxExp = 1000f;
    int nowLevel = 1;
    int maxLevel = 10;
    int reviveCoin = 2;
    [SerializeField]
    Vector3 townPosition;

    //스태미나
    float nowSp = 0f;
    float maxSp = 100f;
    bool usedSp; //행동체크
    const float increaseSp = 20f; //스태미나 증가량
    const float restoreTimeSP = 1.5f; //스태미나 회복 딜레이 시간 ,회복할때까지 걸리는 시간
    float nowRestoreTimeSP ; // 스태미나 현재 회복시간,회복하는시간

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
    // 몬스터와 충돌처리
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AttackCollider attackCollider))
            GetDamage(attackCollider.parent.data.damage);
    }
    // 몬스터와 충돌처리
    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out AttackCollider attackCollider))
            GetDamage(attackCollider.parent.data.damage);
    }
    // 몬스터 마법공격 충돌처리
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
    public void AddExp(int value) //인자
    {
        nowExp += value;

        LevelUp();
    }
    private void RestoreSP()//스태미나
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

    private void RestoreSpDelay() //스태미나가 소모되고 회복시간 딜레이에 들어간다. 2
    {
        if (usedSp)
        {
            if (nowRestoreTimeSP < restoreTimeSP)
                nowRestoreTimeSP++;
            else
                usedSp = false;
        }
    }
    public void DecreaseSp(float value_DS) //스태미나 소모 1
    {
        usedSp = true;
        nowRestoreTimeSP = 0;
        if (nowSp - value_DS >= 0)
            nowSp -= value_DS;
        //else
        //    AlertManager.instance.ShowAlert("스태미나가 부족합니다.");
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

        StartCoroutine(_DieRoutine()); // 죽었을 때 실행할 코루틴
    }

    // 왜 이렇게 나누느냐?
    // IsDie 애니메이션이 실행되는 시간을 벌기 위함.
    // 따라서 yield를 쓰기 위한 것.
    IEnumerator _DieRoutine()
    {
        animator.SetTrigger("IsDie"); // 0.5초간 실행이 되더라
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}