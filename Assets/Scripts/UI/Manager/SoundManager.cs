using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public Slider bgmSlider;
    public Slider sfxSlider;
    public BgmPlayer bgmPlayer { get { return _bgmPlayer; } }
    public SfxPlayer sfxPlayer { get { return _sfxPlayer; } }

    [SerializeField]
    Slider masterSlider;
    [SerializeField]
    BgmPlayer _bgmPlayer;
    [SerializeField]
    SfxPlayer _sfxPlayer;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        masterSlider.onValueChanged.AddListener(RefreshSound);
        bgmSlider.onValueChanged.AddListener(RefreshSound);
        sfxSlider.onValueChanged.AddListener(RefreshSound);
    }
    void RefreshSound(float value)
    {
        //_bgmPlayer.volume = bgmSlider.value * masterSlider.value;
        //_sfxPlayer.volume = sfxSlider.value * masterSlider.value;
    }
}
