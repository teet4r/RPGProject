using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //�ۼ��� : �̻��
    //�ۼ��� : 23-01-04 ~
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

    //npcī�޶�
    [SerializeField]
    Vector3 lastMovingVelocity;
   
    public Vector3 targetPosition;
    Camera npcCam;
    //float targetZoomSize = 5f;
   


    //���¹̳�
    float nowSp = 0f;
    float maxSp = 100f;
    bool usedSp;
    int inSSp; //���¹̳� ������
    int recTimeSP; //���׹̳� ȸ�� ������ �ð� ,ȸ���Ҷ����� �ɸ��� �ð�
    int nowrecTimeSP; // ���¹̳� ���� ȸ���ð�,ȸ���ϴ½ð�

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
        if (instance != null) // �̹� instance�� �Ҵ��� �Ǿ� �ִٸ�
        {
            Destroy(gameObject); // ��� ������� ������Ʈ�� ������Ŵ.
            return;
        }
        instance = this; // instance�� ���Ӱ� �Ҵ�
        DontDestroyOnLoad(gameObject); // ���� �ٲ� ������Ʈ�� ������� �ʵ��� ���ִ� �Լ�.

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
    public void AddExp(int value) //����
    {
        nowExp += value;

        LevelUp();

    }
    private void RestoreSP()//���¹̳�
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
            AlertManager.instance.ShowAlert("���¹̳��� �����մϴ�.");
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
            Debug.Log("npc�Դϴ�");
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
