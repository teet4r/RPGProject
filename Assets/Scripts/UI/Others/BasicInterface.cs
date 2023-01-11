using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicInterface : MonoBehaviour
{
    [SerializeField] Image expBar;
    [SerializeField] Text levelText;
    [SerializeField] Text expText;
    [SerializeField] Image hpBar;
    [SerializeField] Image mpBar;
    [SerializeField] Image spBar;
    [SerializeField] Text hpText;
    [SerializeField] Text mpText;

    private void Start()
    {
        StartCoroutine(RefreshBasicInterface());
    }

    IEnumerator RefreshBasicInterface()
    {
        while(true)
        {
            expBar.fillAmount = Player.instance.NowExp / Player.instance.MaxExp;
            levelText.text = $"Lv.{(int)Player.instance.NowLevel}";
            expText.text = "exp " + (Player.instance.NowExp / Player.instance.MaxExp).ToString("0.0") + '%';
            hpBar.fillAmount = Player.instance.curHp / Player.instance.maxHp;
            mpBar.fillAmount = Player.instance.NowMp / Player.instance.MaxMp;
            spBar.fillAmount = Player.instance.NowSp / Player.instance.MaxSp;
            hpText.text = $"{(int)Player.instance.curHp}/{(int)Player.instance.maxHp}";
            mpText.text = $"{(int)Player.instance.NowMp}/{(int)Player.instance.MaxMp}";
            yield return new WaitForSeconds(0.04f);
        }
    }
}