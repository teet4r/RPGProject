using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Completed on 23.01.04
/// </summary>
public class SoundManager : MonoBehaviour
{
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static SoundManager instance = null;

    public BgmPlayer bgmPlayer { get { return _bgmPlayer; } }
    public SfxPlayer sfxPlayer { get { return _sfxPlayer; } }

    [SerializeField]
    BgmPlayer _bgmPlayer;
    [SerializeField]
    SfxPlayer _sfxPlayer;
}
