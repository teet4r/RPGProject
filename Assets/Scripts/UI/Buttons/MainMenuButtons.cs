using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtons : MonoBehaviour
{
    // 작성자 : 김두현
    // 22.12.16 수정 조아라
    [SerializeField] GameObject optionWindow;
    public void SelectGameStartButton()
    {
        SceneManager.LoadScene("InGame");
    }
    public void SelectOptionButton() //얘 하나로 열고닫기 가능
    {
        optionWindow.SetActive(!optionWindow.activeSelf);
    }
    
    public void SelectGameExitButton()
    {
        Application.Quit();
    }
}