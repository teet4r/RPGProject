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
    // 작성자 : 김두현
    // 22.12.16 수정 조아라
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
    public void SelectOptionButton() //얘 하나로 열고닫기 가능
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