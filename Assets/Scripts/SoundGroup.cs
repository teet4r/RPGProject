using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundGroup : MonoBehaviour
{
    void Awake()
    {
        _masterSlider.onValueChanged.AddListener(delegate
        {
            SoundManager.instance.bgmPlayer.RefreshVolume(_bgmSlider.value * _masterSlider.value);
            SoundManager.instance.sfxPlayer.RefreshVolume(_sfxSlider.value * _masterSlider.value);
        });
        _bgmSlider.onValueChanged.AddListener(delegate
        {
            SoundManager.instance.bgmPlayer.RefreshVolume(_bgmSlider.value * _masterSlider.value);
        });
        _sfxSlider.onValueChanged.AddListener(delegate
        {
            SoundManager.instance.sfxPlayer.RefreshVolume(_sfxSlider.value * _masterSlider.value);
        });
    }

    [SerializeField]
    Slider _masterSlider;
    [SerializeField]
    Slider _bgmSlider;
    [SerializeField]
    Slider _sfxSlider;
}
