using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    Slider masterSlider;
    public static SoundManager instance;

    public Slider bgmSlider;
    public Slider sfxSlider;

    AudioSource bgmPlayer;
    AudioSource sfxPlayer;

    void Awake()
    {
        instance = this;
        bgmPlayer=GameObject.Find("BgmPlayer").GetComponent<AudioSource>(); 
        sfxPlayer=GameObject.Find("SfxPlayer").GetComponent<AudioSource>();

        masterSlider.onValueChanged.AddListener(RefreshSound);
        bgmSlider.onValueChanged.AddListener(RefreshSound);
        sfxSlider.onValueChanged.AddListener(RefreshSound);
    }
    void RefreshSound(float value)
    {
        bgmPlayer.volume = bgmSlider.value * masterSlider.value;
        sfxPlayer.volume=sfxSlider.value * masterSlider.value;
    }

}
