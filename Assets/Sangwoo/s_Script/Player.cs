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

    //���¹̳�
    float nowSp = 0f;
    float maxSp = 100f;
    bool usedSp; //�ൿüũ
    const float increaseSp = 20f; //���¹̳� ������
    const float restoreTimeSP = 1.5f; //���¹̳� ȸ�� ������ �ð� ,ȸ���Ҷ����� �ɸ��� �ð�
    float nowRestoreTimeSP ; // ���¹̳� ���� ȸ���ð�,ȸ���ϴ½ð�

    float atk = 10f;
    float atkSpd = 30f;
    [SerializeField]
    Animation animation; //�ִϸ��̼��� ��������
    [SerializeField]
    Animator animator; //�ִϸ����� ��������
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
        if (instance != null) // �̹� instance�� �Ҵ��� �Ǿ� �ִٸ�
        {
            Destroy(gameObject); // ��� ������� ������Ʈ�� ������Ŵ.
            return;
        }
        instance = this; // instance�� ���Ӱ� �Ҵ�
        DontDestroyOnLoad(gameObject); // ���� �ٲ� ������Ʈ�� ������� �ʵ��� ���ִ� �Լ�.

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
    public void AddExp(int value) //����
    {
        nowExp += value;

        LevelUp();

    }
    private void RestoreSP()//���¹̳�
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

    private void RestoreSpDelay() //���¹̳��� �Ҹ�ǰ� ȸ���ð� �����̿� ����. 2
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
    public void DecreaseSp(float value_DS) //���¹̳� �Ҹ� 1
    {
        usedSp = true;
        nowRestoreTimeSP = 0;
        if (nowSp - value_DS >= 0)
        {
            nowSp -= value_DS;
        }
        //else
        //    AlertManager.instance.ShowAlert("���¹̳��� �����մϴ�.");
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
        //�ִϸ����Ϳ� �ִ°� �ٰ����԰�
        animator.GetCurrentAnimatorStateInfo(0);
        //�ִϸ������� ���� ���� ������������
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
