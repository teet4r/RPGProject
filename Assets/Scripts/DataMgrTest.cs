using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataMgrTest : MonoBehaviour
{
    public Slider MasterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public void Save() //저장 테스트
    {
        PlayerPrefs.SetFloat("Master",MasterSlider.value); //마스터 값
        PlayerPrefs.SetFloat("Bgm", bgmSlider.value);
        PlayerPrefs.SetFloat("Sfx", sfxSlider.value);
    }
}
