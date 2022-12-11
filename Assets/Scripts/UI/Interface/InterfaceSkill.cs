using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InterfaceSkill : MonoBehaviour
{
    public Image FillImg;//남은 시간 시각적 표시
    public float time_coolTime; //쿨타임으로 사용할 시간
    public float time_current; //스킬 재사용까지 남은 시간
    public float time_start; //time.Time과 비교해서 time_current를 만들기 위해 시간을 저장
    public bool isEnded = true; //쿨타임이 끝났을 떄 true

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
