using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCanvas : MonoBehaviour
{
    public static SettingCanvas instance;
    public GameObject settingBackground;

    void Awake()
    {
        #region Singleton Pattern
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        #endregion

        settingBackground.SetActive(false);
    }
    
    /// <summary>
    /// ������ ��ư��
    /// </summary>
    public void Exit()
    {
        SoundManager.Instance.SfxAudio.Play("ButtonCancel");
        settingBackground.SetActive(false);
    }
}
