using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    [SerializeField] Skill skill;
    [SerializeField] Image slotImage;
    [SerializeField] KeyCode inputKey;

    private void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            UseQuickSlot();
        }
    }

    public void SetQuickSlot(Skill _skill)
    {
        skill = _skill;
        slotImage.sprite = _skill.SkillImage;
    }

    public void SetQuickSlotInputKey(KeyCode _keycode)
    {
        inputKey = _keycode;
    }

    public void ClearQuickSlot()
    {
        skill = null;
        slotImage.sprite = null;
    }

    public void UseQuickSlot()
    {

    }
}