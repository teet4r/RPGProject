using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Skill skill;
    [SerializeField] Image slotImage;
    [SerializeField] Text itemNum;
    [SerializeField] KeyCode inputKey;

    private void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            UseQuickSlot();
        }
    }

    public void SetQuickSlot(Item _item)
    {
        item = _item;
        slotImage.sprite = _item.ItemImage;
    }

    public void SetQuickSlot(Skill _skill)
    {
        skill = _skill;
        slotImage.sprite = _skill.SkillImage;
    }

    public void RefreshQuickSlotItemNum(int num)
    {
        itemNum.text = num.ToString();
    }

    public void SetQuickSlotInputKey(KeyCode _keycode)
    {
        inputKey = _keycode;
    }

    public void ClearQuickSlot()
    {
        item = null;
        skill = null;
        slotImage.sprite = null;
        itemNum.text = "";
    }

    public void UseQuickSlot()
    {

    }
}