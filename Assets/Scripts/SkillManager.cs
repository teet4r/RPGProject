using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // 작성자 : 김두현
    
    // AddSkillExp(SkillInfo _skillInfo, int _exp) - 해당 스킬로 적을 공격할 때마다 호출
    // SkillManager.instance.AddSkillExp(SKillManager.instance.SkillInfos[(int)SkillManager.SKILLTYPE.SAMPLE],num);

    // CanUseSkill(SkillInfo _skillInfo) - 스킬 쿨타임이 다 돌았는지 체크
    // if(SkillManager.instance.CanUseSkill(SkillManager.instance.SkillInfos[(int)SkillManager.SKILLTYPE.SAMPLE]);
    
    public static SkillManager instance;

    public enum SKILLTYPE
    { SWORD1, ENUM_SIZE }
    [SerializeField] SkillInfo[] skillInfos;

    public SkillInfo[] SkillInfos { get { return skillInfos; } }

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

    private void Update()
    {
        RefreshSkillCoolTime();
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

    public void AddSkillExp(SkillInfo _skillInfo, int _exp)
    {
        _skillInfo.AddSkillExp(_exp);
        CheckSkillExp(_skillInfo);
    }

    public bool CanUseSkill(SkillInfo _skillInfo)
    {
        if (_skillInfo.SkillAble)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [System.Serializable]
    public class SkillInfo
    {
        [SerializeField] SKILLTYPE skillType;
        [SerializeField] Skill skill;
        [SerializeField] float coolTimeLeft = 0; // 남은 쿨타임
        [SerializeField] string skillInfo; // 레벨에 따른 스킬 정보
        [SerializeField] bool skillAble = false; // 스킬을 사용 가능한지 - 쿨타임
        [SerializeField] bool skillUsable = false; // 레벨업을 해서 스킬을 습득했는지
        [SerializeField] int skillLevel = 0; // 스킬 레벨
        [SerializeField] int skillExp = 0; // 스킬 현재 경험치

        public SKILLTYPE SkillType { get { return skillType; } }
        public Skill Skill { get { return skill; } }
        public float CoolTimeLeft { get { return coolTimeLeft; } }
        public bool SkillAble { get { return skillAble; } }
        public bool SkillUsable { get { return skillUsable; } }

        public void RefreshSkillCoolTime()
        {
            if (!SkillAble)
            {
                coolTimeLeft -= Time.deltaTime;
            }
        }

        public void SetSkillInfo()
        {
            if (skillLevel > 0)
            {
                skillInfo = skill.SkillInfos[skillLevel - 1];
            }
            else
            {
                skillInfo = "";
            }
        }

        public void SkillLevelUp()
        {
            skillExp = skillExp - skill.MaxExp[skillLevel - 1];
            skillLevel++;
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

        public void SkillActivate()
        {
            skillUsable = true;
        }
    }
}