using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTime : MonoBehaviour
{
    public Text CooltimeTxt; //���� �ð� �ؽ�Ʈ ǥ��
    public Image FillImg;//���� �ð� �ð��� ǥ��
    public float time_coolTime; //��Ÿ������ ����� �ð�
    private float time_current; //��ų ������� ���� �ð�
    private float time_start; //time.Time�� ���ؼ� time_current�� ����� ���� �ð��� ����
    private bool isEnded = true; //��Ÿ���� ������ �� true

    public void Click()
    {
        Init_UI();
        TriggerSkill();
    }
    void Update()
    {
       if(isEnded) return;
        Check_CoolTime();
    }
    void Init_UI() //�̹����� 360�� �ð� �ݴ�������� ȸ���ϰ� ����
    {
        FillImg.type = Image.Type.Filled; //ä��� Ÿ��
        FillImg.fillMethod = Image.FillMethod.Radial360; //360���� ä����
        FillImg.fillOrigin = (int)Image.Origin360.Top; //�ð������ ä����
        FillImg.fillClockwise = false;
    }
    void Check_CoolTime() //��ų ������� ���� �ð��� �˻� �� ǥ��
    {
        time_current = Time.time - time_start;
        if(time_current<time_coolTime)
        {
            Set_FillAmount(time_coolTime - time_current);
        }
        else if(!isEnded)
        {
            End_CoolTime();
        }
    }
    void End_CoolTime() //��Ÿ���� �P���� ��ų ������ �������� ����
    {
        Set_FillAmount(0);
        isEnded = true;
        CooltimeTxt.gameObject.SetActive(false);
    }
    void TriggerSkill() //��ų �ߵ�
    {
        if (!isEnded)
        {
            Debug.LogError("���");
            return;
        }
        ResetCoolTime();
        Debug.LogError("trigger skill");
    }
    void ResetCoolTime() //��Ÿ�� ����
    {
        CooltimeTxt.gameObject.SetActive(true);
        time_current = time_coolTime;
        time_start= Time.time;
        Set_FillAmount(time_coolTime);
        isEnded = false;
    }
    void Set_FillAmount(float _value) //��ų ���� �ð� ����ȭ
    {
        FillImg.fillAmount = _value / time_coolTime;
        string txt = _value.ToString("0.0");
        CooltimeTxt.text = txt;
    }
}
