using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCoolTime : MonoBehaviour
{
    // �ۼ��� : ���ƶ�
    [SerializeField] Text CooltimeTxt; //���� �ð� �ؽ�Ʈ ǥ��
    [SerializeField] Image FillImg; //���� �ð� �ð��� ǥ��
    private float time_coolTime;
    private float time_current;
    private float time_start; //time.Time�� ���ؼ� time_current�� ����� ���� �ð��� ����
    private bool isEnded = true; //��Ÿ���� ������ �� true

    public bool IsEnded { get { return isEnded; } }

    private void Start()
    {
        Check_CoolTime();
    }

    void Check_CoolTime() //��ų ������� ���� �ð��� �˻� �� ǥ��
    {
        time_current = Time.time - time_start;
        if (time_current < time_coolTime)
        {
            Set_FillAmount(time_coolTime - time_current);
        }
        else if (!isEnded)
        {
            End_CoolTime();
        }
    }
    void End_CoolTime() //��Ÿ���� ������ ��ų ������ �������� ����
    {
        Set_FillAmount(0);
        isEnded = true;
        CooltimeTxt.gameObject.SetActive(false);
    }
    void TriggerSlot() //���� �ߵ�
    {
        if (!isEnded)
        {
            return;
        }
        ResetCoolTime();
    }
    void ResetCoolTime() //��Ÿ�� ����
    {
        CooltimeTxt.gameObject.SetActive(true);
        time_current = time_coolTime;
        time_start = Time.time;
        Set_FillAmount(time_coolTime);
        isEnded = false;
    }
    void Set_FillAmount(float _value) //��ų ���� �ð� ����ȭ
    {
        FillImg.fillAmount = _value / time_coolTime;
        CooltimeTxt.text = _value.ToString("0.0") + 's';
    }
}