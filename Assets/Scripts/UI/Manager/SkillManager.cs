using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    const float checkTime = 0.1f;
    readonly float[] skillCoolTimeMax = { 8f, 12f };

    [SerializeField] float[] skillCoolTime = new float[(int)SKILL_TYPE.ENUM_SIZE];
    [SerializeField] bool[] skillUsable = new bool[(int)SKILL_TYPE.ENUM_SIZE];

    [SerializeField] GameObject skillSlotGroup;

    public enum SKILL_TYPE { SWORD, SHIELD, ENUM_SIZE }

    public float CheckTime { get { return checkTime; } }
    public float[] SkillCoolTimeMax { get { return skillCoolTimeMax; } }

    public float[] SkillCoolTime { get { return skillCoolTime; } }
    public bool[] SkillUsable { get { return skillUsable; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < (int)SKILL_TYPE.ENUM_SIZE; i++)
        {
            skillCoolTime[i] = 0f;
            skillUsable[i] = true;
        }
        StartCoroutine(CheckSkillCoolTime());
    }

    public void UseSkill(int _num)
    {
        if (skillUsable[_num])
        {
            skillUsable[_num] = false;
            skillCoolTime[_num] = skillCoolTimeMax[_num];
        }
    }

    IEnumerator CheckSkillCoolTime()
    {
        while (true)
        {
            for (int i = 0; i < (int)SKILL_TYPE.ENUM_SIZE; i++)
            {
                if (skillCoolTime[i] <= 0f)
                {
                    skillCoolTime[i] = 0f;
                    skillUsable[i] = true;
                }
                if (skillUsable[i])
                {
                    continue;
                }
                else
                {
                    skillCoolTime[i] -= checkTime;
                }
            }
            yield return new WaitForSeconds(checkTime);
        }
    }
}