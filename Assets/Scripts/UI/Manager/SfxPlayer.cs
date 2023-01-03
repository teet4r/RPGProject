using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// written by ±Ë»Ò¿Á
/// written date: 2023.01.03
/// </summary>
public class SfxPlayer : MonoBehaviour
{
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public bool isMute
    {
        get { return _audioSource.mute; }
        set { _audioSource.mute = value; }
    }
    AudioSource _audioSource;
}

public enum Sfx
{

}