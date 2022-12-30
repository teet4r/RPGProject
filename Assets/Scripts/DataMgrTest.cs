using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataMgrTest : MonoBehaviour
{
    public Slider MasterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public void Save() //���� �׽�Ʈ
    {
        PlayerPrefs.SetFloat("Master",MasterSlider.value); //������ ��
        PlayerPrefs.SetFloat("Bgm", bgmSlider.value);
        PlayerPrefs.SetFloat("Sfx", sfxSlider.value);
    }
}
