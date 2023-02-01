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
            SoundManager.Instance.BgmAudio.Volume = _bgmSlider.value * _masterSlider.value;
            SoundManager.Instance.SfxAudio.Volume = _sfxSlider.value * _masterSlider.value;
        });
        _bgmSlider.onValueChanged.AddListener(delegate
        {
            SoundManager.Instance.BgmAudio.Volume = _bgmSlider.value * _masterSlider.value;
        });
        _sfxSlider.onValueChanged.AddListener(delegate
        {
            SoundManager.Instance.SfxAudio.Volume = _sfxSlider.value * _masterSlider.value;
        });
    }

    [SerializeField]
    Slider _masterSlider;
    [SerializeField]
    Slider _bgmSlider;
    [SerializeField]
    Slider _sfxSlider;
}
