using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject optionWindow;
    [SerializeField] GameObject howToWindow;
    public void SelectGameStartButton()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
    public void SelectHowToButton()
    {
        howToWindow.SetActive(!howToWindow.activeSelf);
    }
    public void SelectOptionButton()
    {
        optionWindow.SetActive(!optionWindow.activeSelf);
    }
    public void SelectGameExitButton()
    {
        Application.Quit();
    }
}