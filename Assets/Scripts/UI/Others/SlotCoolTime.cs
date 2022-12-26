using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCoolTime : MonoBehaviour
{
    // 작성자 : 조아라
    [SerializeField] Text CooltimeTxt; //남은 시간 텍스트 표시
    [SerializeField] Image FillImg; //남은 시간 시각적 표시
    private float time_coolTime;
    private float time_current;
    private float time_start; //time.Time과 비교해서 time_current를 만들기 위해 시간을 저장
    private bool isEnded = true; //쿨타임이 끝났을 떄 true

    public bool IsEnded { get { return isEnded; } }

    private void Start()
    {
        Check_CoolTime();
    }

    void Check_CoolTime() //스킬 재사용까지 남은 시간을 검사 및 표시
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
    void End_CoolTime() //쿨타임이 끝나서 스킬 재사용이 가능해진 시점
    {
        Set_FillAmount(0);
        isEnded = true;
        CooltimeTxt.gameObject.SetActive(false);
    }
    void TriggerSlot() //슬롯 발동
    {
        if (!isEnded)
        {
            return;
        }
        ResetCoolTime();
    }
    void ResetCoolTime() //쿨타임 리셋
    {
        CooltimeTxt.gameObject.SetActive(true);
        time_current = time_coolTime;
        time_start = Time.time;
        Set_FillAmount(time_coolTime);
        isEnded = false;
    }
    void Set_FillAmount(float _value) //스킬 재사용 시간 최적화
    {
        FillImg.fillAmount = _value / time_coolTime;
        CooltimeTxt.text = _value.ToString("0.0") + 's';
    }
}