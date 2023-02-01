using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuButtons : MonoBehaviour
{
    // �ۼ��� : �����
    // 22.12.16 ���� ���ƶ�

    public void SelectGameStartButton()
    {
        //SceneManager.LoadScene("InGame");
        SoundManager.Instance.SfxAudio.Play("MainMenuButton");
        LoadingProgress.LoadScene("InGame");
    }
    public void SelectOptionButton() //�� �ϳ��� ����ݱ� ����
    {
        SoundManager.Instance.SfxAudio.Play("MainMenuButton");
        SettingCanvas.instance.settingBackground.SetActive(!SettingCanvas.instance.settingBackground.activeSelf);
    }
    
    public void SelectGameExitButton()
    {
        SoundManager.Instance.SfxAudio.Play("MainMenuButton");
        Application.Quit();
    }
    
}