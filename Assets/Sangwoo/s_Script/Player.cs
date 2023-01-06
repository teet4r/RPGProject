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

    //npc카메라
    [SerializeField]
    Vector3 lastMovingVelocity;
   
    public Vector3 targetPosition;
    Camera npcCam;
    //float targetZoomSize = 5f;
   


    //스태미나
    float nowSp = 0f;
    float maxSp = 100f;
    bool usedSp;
    int inSSp; //스태미나 증가량
    int recTimeSP; //스테미나 회복 딜레이 시간 ,회복할때까지 걸리는 시간
    int nowrecTimeSP; // 스태미나 현재 회복시간,회복하는시간

    float atk = 10f;
    float atkSpd = 30f;

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
        if (usedSp)
        {
            if (nowrecTimeSP < recTimeSP)
                nowrecTimeSP++;
            else
                usedSp = false;
        }
    }
    private void DecreaseSp(int value_DS)
    {
        usedSp = true;
        recTimeSP = 0;
        if (nowSp - value_DS >= 0)
        {
            nowSp -= value_DS;
        }
        else
            AlertManager.instance.ShowAlert("스태미나가 부족합니다.");
    }
    public void Revive()
    {
        nowHp = reviveCoin-- * maxHp * 0.5f;
        reviveCoin = 2;

    }
    public void MoveToTown()
    {
        transform.position = townPosition;
    }

    private void OnTriggerEnter(Collider col)
    {
        
        if(col.gameObject.tag == "NPC")
        {
            Debug.Log("npc입니당");
            targetPosition = col.gameObject.transform.position;
            Debug.Log(targetPosition);
        }
    }
    
    private void NPCZoomCamera()
    {

    }

    void Update()
    {

    }
}
