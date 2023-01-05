using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //작성자 : 이상우
    //작성일 : 23-01-04 ~
    public static Player instance = null;

    //public string name { }
    public float nowHp = 100f;
    public float maxHp = 0f;
    public float nowMp = 0f;
    public float maxMp = 100f;
    public float nowExp = 0f;
    public float maxExp = 1000f;
    public int nowLevel = 1;
    public int maxLevel = 100;

    //스태미나
    public float nowSp = 0f;      
    public float maxSp = 1000f;
    public bool usedSp;
    public int inSSp; //스태미나 증가량
    public int recTimeSP; //스테미나 회복 딜레이 시간 ,회복할때까지 걸리는 시간
    public int nowrecTimeSP; // 스태미나 현재 회복시간,회복하는시간
    




    public float MP = 100f;

    public float Atk = 10f;
    public float AtkSpd = 30f;
    //public float

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

    //함수  
    public void AddHp(float value)
    {
        nowHp = Mathf.Min(nowHp + value, maxHp);
    }

    public void AddMp(float value2)
    {
        nowMp = Mathf.Min(nowHp + value2, maxMp);
    }

    

    public void LevelUp()
    {
        if (nowExp == maxExp)
        {
            nowLevel += 1;

            Debug.Log("레벨업!!");

        }
        nowExp -= maxExp;
        if (nowExp < 0)
            nowExp *= -1;
    }

 
    private void RestoreSP(int value_RS)//스태미나
    {
        //스태미너 자연회복 초당 20퍼 
        //구르기 1회 25퍼 감소
        //달리가 초당 10퍼


        if (usedSp)
        {
            if (nowrecTimeSP < recTimeSP)
                nowrecTimeSP++;
            else
                usedSp = false;
        }


        if(!usedSp && nowSp < maxSp)
        {
            //nowSp += 
        }
    }

    private void DecreaseSp(int value_DS)
    {
        usedSp = true;
        recTimeSP = 0;
        if (nowSp - value_DS > 0)
        {
            nowSp -= value_DS;
        }
        else
            nowSp = 0;
        
    }

    private float GetnowSp()
    {
         return nowSp;
    }

    void Start()
    {

    }
    
    void Update()
    {
        
    }
}
