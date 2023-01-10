using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoWindow : MonoBehaviour
{
    const float refreshTime = 0.25f;

    [SerializeField] Text levelText;
    [SerializeField] Image expBarImage;
    [SerializeField] Text atkText;
    [SerializeField] Text hpText;
    [SerializeField] Text mpText;
    [SerializeField] Text spText;

    private void Start()
    {
        StartCoroutine(RefreshStatInfos());
    }

    IEnumerator RefreshStatInfos()
    {
        while (true)
        {
            levelText.text = $"LV. {(int)Player.instance.NowLevel}";
            expBarImage.fillAmount = Player.instance.NowExp / Player.instance.MaxExp;
            atkText.text = $"°ø°Ý·Â : {(int)Player.instance.Atk}";
            hpText.text = $"HP : {(int)Player.instance.curHp} / {(int)Player.instance.maxHp}";
            mpText.text = $"MP : {(int)Player.instance.NowMp} / {(int)Player.instance.MaxMp}";
            spText.text = $"SP : {(int)Player.instance.NowSp} / {(int)Player.instance.MaxSp}";
            yield return new WaitForSeconds(refreshTime);
        }
    }
}