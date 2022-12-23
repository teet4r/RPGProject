using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // 작성자 : 김두현
    public static SkillManager instance;

    public enum SKILLTYPE
    { SWORD1, SWORD2, AXE1, AXE2, SHIELD1, SHIELD2, ENUM_SIZE }
    [SerializeField] SkillInfo[] skillInfos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < (int)SKILLTYPE.ENUM_SIZE; i++)
        {
            skillInfos[i].RefreshSkillCoolTime();
        }
    }

    private void Update()
    {

    }

    void CheckSkillExp(SkillInfo _skillInfo)
    {
        while (_skillInfo.CanLevelUp())
        {
            _skillInfo.SkillLevelUp();
        }
    }

    void RefreshSkillCoolTime()
    {
        for (int i = 0; i < skillInfos.Length; i++)
        {
            if (skillInfos[i].SkillAble)
            {
                continue;
            }
            else
            {
                skillInfos[i].RefreshSkillCoolTime();
            }
        }
    }

    /*
    public void AddSkillExp(SkillInfo _skillInfo, int _exp)
    {
        _skillInfo.AddSkillExp(_exp);
    }
    */

    [System.Serializable]
    private class SkillInfo
    {
        [SerializeField] SKILLTYPE skillType;
        [SerializeField] Skill skill;
        [SerializeField] float coolTimeLeft = 0;
        [SerializeField] string[] skillInfos;
        [SerializeField] string skillInfo;
        [SerializeField] bool skillAble = false;
        [SerializeField] bool skillUsable = false;
        [SerializeField] int skillLevel = 0;
        [SerializeField] int skillExp = 0;

        public SKILLTYPE SkillType { get { return skillType; } }
        public Skill Skill { get { return skill; } }
        public float CoolTimeLeft { get { return coolTimeLeft; } }
        public bool SkillAble { get { return skillAble; } }

        public void RefreshSkillCoolTime()
        {
            if (!SkillAble)
            {
                coolTimeLeft -= Time.deltaTime;
            }
        }

        public void SetSkillInfo()
        {
            skillInfo = skillInfos[skillLevel];
        }

        public void SkillLevelUp()
        {
            skillExp = skillExp - skill.MaxExp[0];
            skillLevel++;
        }

        public void SkillExpUp(int _exp)
        {
            skillExp += _exp;
        }

        public bool CanLevelUp()
        {
            if (skillExp >= skill.MaxExp[skillLevel])
            {
                return true;
            }
            else return false;
        }

        public void AddSkillExp(int _exp)
        {
            skillExp += _exp;
        }
    }
}