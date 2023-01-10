using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlot : MonoBehaviour
{
    [SerializeField] Skill skill;
    [SerializeField] Image skillImage;
    [SerializeField] Image coolTimeImage;
    [SerializeField] Text coolTimeText;

    public Skill Skill { get { return skill; } }

    private void Start()
    {
        skillImage.sprite = skill.SkillImage;
        StartCoroutine(RefreshSkillCoolTimeInfo());
    }

    IEnumerator RefreshSkillCoolTimeInfo()
    {
        while(true)
        {
            if (!SkillManager.instance.SkillUsable[transform.GetSiblingIndex()])
            {
                SetCoolTimeText();
                SetCoolTimeImage(SkillManager.instance.SkillCoolTime[transform.GetSiblingIndex()] / SkillManager.instance.SkillCoolTimeMax[transform.GetSiblingIndex()]);
            }
            else
            {
                coolTimeText.gameObject.SetActive(false);
                coolTimeImage.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(SkillManager.instance.CheckTime);
        }
    }

    void SetCoolTimeText()
    {
        coolTimeText.gameObject.SetActive(true);
        coolTimeText.text = $"ÄðÅ¸ÀÓ : {(int)SkillManager.instance.SkillCoolTime[transform.GetSiblingIndex()]}";
    }

    void SetCoolTimeImage(float _fillAmount)
    {
        coolTimeImage.gameObject.SetActive(true);
        coolTimeImage.fillAmount = _fillAmount;
    }
}