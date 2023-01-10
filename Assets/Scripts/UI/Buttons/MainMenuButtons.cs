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
    public GameObject circle;
    public List<GameObject> btns;

    void Start()
    {
        foreach(GameObject btn in btns)
        {
            btn.GetComponent<Button>().onClick.AddListener(() => clickEffect(btn));
        }   
    }
    void clickEffect(GameObject gameObject)
    {
        Instantiate(circle, gameObject.transform.position, quaternion.identity);
    }
    public void SelectGameStartButton()
    {
        //SceneManager.LoadScene("InGame");
        SoundManager.instance.sfxPlayer.Play(Sfx.MainMenuButton);
        LoadingProgress.LoadScene("InGame");
    }
    public void SelectOptionButton() //�� �ϳ��� ����ݱ� ����
    {
        SoundManager.instance.sfxPlayer.Play(Sfx.MainMenuButton);
        SettingCanvas.instance.settingBackground.SetActive(!SettingCanvas.instance.settingBackground.activeSelf);
    }
    
    public void SelectGameExitButton()
    {
        SoundManager.instance.sfxPlayer.Play(Sfx.MainMenuButton);
        Application.Quit();
    }
    
}