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
    /// 나가는 버튼용
    /// </summary>
    public void Exit()
    {
        SoundManager.Instance.SfxAudio.Play("ButtonCancel");
        settingBackground.SetActive(false);
    }
}
