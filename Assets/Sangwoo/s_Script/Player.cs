using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //작성자 : 이상우
    //작성일 : 23-01-04 ~
    public static Player instance = null;

    //public string name { }
    float nowHp = 0f;
    float maxHp = 100f;
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

    float atk = 10f;
    float atkSpd = 30f;
    [SerializeField]
    Animation animation; //애니메이션을 가져오기
    [SerializeField]
    Animator animator; //애니메이터 가져오기
    const float nowPlayAnimationTime = 1f;
    const float finishPlayAnimationTime = 0f;


    public float NowHp { get { return nowHp; } }
    public float MaxHp { get { return maxHp; } }

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

    void Awake()
    {
        #region Singleton Pattern
        if (instance != null) // 이미 instance에 할당이 되어 있다면
        {
            Destroy(gameObject); // 방금 만들어진 오브젝트를 삭제시킴.
            return;
        }
        instance = this; // instance에 새롭게 할당
        DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 오브젝트가 사라지지 않도록 해주는 함수.

        #endregion

    }
    void OnEnable()
    {
        nowSp = maxSp;
    }

    public void AddHp(float value)
    {
        nowHp = Mathf.Min(nowHp + value, maxHp);
    }

    public void AddMp(float value2)
    {
        nowMp = Mathf.Min(nowHp + value2, maxMp);
    }

    void LevelUp()
    {
        while (nowExp >= maxExp)
        {
            nowLevel += 1;
            maxHp *= 1.1f;
            maxMp *= 1.1f;
            maxExp *= 1.3f;
            atk *= 1.1f;
            nowHp = maxHp;
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
       if(usedSp==false)
       {
            nowSp += increaseSp * Time.deltaTime;
            if (nowSp>maxSp)
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
            {
                usedSp = false;
               
            }
                
        }
    }
    public void DecreaseSp(float value_DS) //스태미나 소모 1
    {
        usedSp = true;
        nowRestoreTimeSP = 0;
        if (nowSp - value_DS >= 0)
        {
            nowSp -= value_DS;
        }
        //else
        //    AlertManager.instance.ShowAlert("스태미나가 부족합니다.");
    }
    public void Revive()
    {
        nowHp = reviveCoin-- * maxHp * 0.5f;
       

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
    public void BladeActive()
    {
        
    }
    public void AnimationPlayCheck()
    {
        animator = GetComponent<Animator>(); 
        //애니메이터에 있는거 다가져왔고
        animator.GetCurrentAnimatorStateInfo(0);
        //애니메이터의 현재 상태 정보가져오고
       // var stateInfo = new AnimatorStateInfo
       
        if (usedSp)
        {
            if (nowPlayAnimationTime < finishPlayAnimationTime)
            {

            }
                 
            else
            {
                usedSp = false;

            }

        }

    }
 
}
