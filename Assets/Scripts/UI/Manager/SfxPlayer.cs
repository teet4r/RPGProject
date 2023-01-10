using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxPlayer : MonoBehaviour
{
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        Initialize();
    }

    public void Play(Sfx name)
    {
        _audioSource.PlayOneShot(_clips[(int)name]);
    }
    public void Play(string name)
    {
        if (!_clipDictionary.ContainsKey(name))
        {
            Debug.LogError("This name of Sfx is not found.");
            return;
        }

        _audioSource.PlayOneShot(_clipDictionary[name]);
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
    [Tooltip("클립의 순서는 enum Sfx와 동기화되어야 함.")]
    [SerializeField] AudioClip[] _clips;
    AudioSource _audioSource;
    Dictionary<string, AudioClip> _clipDictionary = new Dictionary<string, AudioClip>();
}

public enum Sfx
{
    Alert, ButtonCancel, ButtonConfirm, BuyButton, InventoryWindowClose, InventoryWindowOpen,
    ItemAcquire, ItemSlotSwitch, PopUpClose, PopUpOpen, QuestWindowClose, QuestWindowOpen,
    Revive, SellButton, ToggleButton, UsePosion, MouseClick, MainMenuButton, MainMenuButtonMouse
}