using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// written by ±Ë»Ò¿Á
/// written date: 2023.01.03
/// </summary>
public class BgmPlayer : MonoBehaviour
{
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void OnEnable()
    {
        _audioSource.playOnAwake = true;
        _audioSource.loop = true;
    }

    public bool isMute
    {
        get { return _audioSource.mute; }
        set { _audioSource.mute = value; }
    }
    AudioSource _audioSource;
}

public enum Bgm
{

}