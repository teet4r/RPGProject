using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // 작성자 : 김두현
    public static SkillManager instance;

    Dictionary<SKILLTYPE, bool> skillAble = new();

    public enum SKILLTYPE
    { SWORD1, SWORD2, AXE1, AXE2, SHIELD1, SHIELD2, ENUM_SIZE }

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
            skillAble.Add((SKILLTYPE)i, false);
        }
    }

    private void Update()
    {

    }

    public class SkillInfo
    {
        [SerializeField] SkillManager.SKILLTYPE skillType;
        [SerializeField] float coolTime;
        [SerializeField] float coolTimeLeft;
    }
}