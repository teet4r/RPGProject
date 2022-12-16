using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtons : MonoBehaviour
{
    // �ۼ��� : �����
    // 22.12.16 ���� ���ƶ�
    [SerializeField] GameObject optionWindow;
    public void SelectGameStartButton()
    {
        SceneManager.LoadScene("InGame");
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