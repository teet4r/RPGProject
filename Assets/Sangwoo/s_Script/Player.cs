using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public static Player instance = null;

    //public string name { }
    public float nowHp = 100f;
    public float maxHp = 0f;
    public float nowMp = 0f;
    public float maxMp = 100f;
    public float nowExp = 0f;
    public float maxExp = 1000f;
    public int nowLevel = 0;
    public int maxLevel = 100;
    public int nowSp = 0;
    public int MaxSp = 0;




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





    void Start()
    {

    }
    
    void Update()
    {
        
    }
}
