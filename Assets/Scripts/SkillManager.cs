using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // �ۼ��� : �����
    
    // AddSkillExp(SkillInfo _skillInfo, int _exp) - �ش� ��ų�� ���� ������ ������ ȣ��
    // SkillManager.instance.AddSkillExp(SKillManager.instance.SkillInfos[(int)SkillManager.SKILLTYPE.SAMPLE],num);

    // CanUseSkill(SkillInfo _skillInfo) - ��ų ��Ÿ���� �� ���Ҵ��� üũ
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
        [SerializeField] float coolTimeLeft = 0; // ���� ��Ÿ��
        [SerializeField] string skillInfo; // ������ ���� ��ų ����
        [SerializeField] bool skillAble = false; // ��ų�� ��� �������� - ��Ÿ��
        [SerializeField] bool skillUsable = false; // �������� �ؼ� ��ų�� �����ߴ���
        [SerializeField] int skillLevel = 0; // ��ų ����
        [SerializeField] int skillExp = 0; // ��ų ���� ����ġ

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