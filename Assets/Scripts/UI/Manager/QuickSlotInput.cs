using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotInput : MonoBehaviour
{
    // 작성자 : 김두현
    [SerializeField] KeyCode inputKey;
    [SerializeField] Text inputKeyText;

    public void SetQuickSlotInputKey(KeyCode _keycode)
    {
        inputKey = _keycode;
        inputKeyText.text = _keycode.ToString();
    }

    public void UseQuickSlot()
    {
        // 스킬, 포션 등 슬롯의 타입이 무엇인지 체크
        // if ()
        // {
            // 스킬이 사용 가능한지 마나, 쿨타임, 무기 착용 여부 등 체크
            // if (SkillManager.instance.CanUseSkill((int)SkillManager.SKILL(gameObject.transform.GetSiblingIndex))
            // {
                // SkillManager.instance.UseSkill((int)SkillManager.SKILL(gameObject.transform.GetSiblingIndex));
            // }
        // }
    }
}