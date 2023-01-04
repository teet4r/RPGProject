using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmPlayer : MonoBehaviour
{
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        Initialize();
    }
    void OnEnable()
    {
        _audioSource.playOnAwake = true;
        _audioSource.loop = true;
    }

    public void Play(Bgm name)
    {
        _audioSource.clip = _clips[(int)name];
        _audioSource.Play();
    }
    public void Play(string name)
    {
        if (!_clipDictionary.ContainsKey(name))
        {
            Debug.LogError("This name of Bgm is not found.");
            return;
        }

        _audioSource.clip = _clipDictionary[name];
        _audioSource.Play();
    }
    public void RefreshVolume(float newVolume)
    {
        _audioSource.volume = newVolume;
    }

    void Initialize()
    {
        for (int i = 0; i < _clips.Length; i++)
            _clipDictionary.Add(_clips[i].name, _clips[i]);
    }

    public bool isMute
    {
        get { return _audioSource.mute; }
        set { _audioSource.mute = value; }
    }
    [Tooltip("클립의 순서는 enum Bgm과 동기화되어야 함.")]
    [SerializeField] AudioClip[] _clips;
    AudioSource _audioSource;
    Dictionary<string, AudioClip> _clipDictionary = new Dictionary<string, AudioClip>();
}

public enum Bgm
{
    ArcadeGameBgm
}