using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotInput : MonoBehaviour
{
    // �ۼ��� : �����
    [SerializeField] KeyCode inputKey;
    [SerializeField] Text inputKeyText;

    public void SetQuickSlotInputKey(KeyCode _keycode)
    {
        inputKey = _keycode;
        inputKeyText.text = _keycode.ToString();
    }

    public void UseQuickSlot()
    {
        // ��ų, ���� �� ������ Ÿ���� �������� üũ
        // if ()
        // {
            // ��ų�� ��� �������� ����, ��Ÿ��, ���� ���� ���� �� üũ
            // if (SkillManager.instance.CanUseSkill((int)SkillManager.SKILL(gameObject.transform.GetSiblingIndex))
            // {
                // SkillManager.instance.UseSkill((int)SkillManager.SKILL(gameObject.transform.GetSiblingIndex));
            // }
        // }
    }
}