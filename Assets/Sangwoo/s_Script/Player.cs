using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //�ۼ��� : �̻��
    //�ۼ��� : 23-01-04 ~
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

    //���¹̳�
    public float nowSp = 0f;      
    public float maxSp = 1000f;
    public bool usedSp;
    public int inSSp; //���¹̳� ������
    public int recTimeSP; //���׹̳� ȸ�� ������ �ð� ,ȸ���Ҷ����� �ɸ��� �ð�
    public int nowrecTimeSP; // ���¹̳� ���� ȸ���ð�,ȸ���ϴ½ð�
    




    public float MP = 100f;

    public float Atk = 10f;
    public float AtkSpd = 30f;
    //public float

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

    //�Լ�  
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

            Debug.Log("������!!");

        }
        nowExp -= maxExp;
        if (nowExp < 0)
            nowExp *= -1;
    }

 
    private void RestoreSP(int value_RS)//���¹̳�
    {
        //���¹̳� �ڿ�ȸ�� �ʴ� 20�� 
        //������ 1ȸ 25�� ����
        //�޸��� �ʴ� 10��


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
