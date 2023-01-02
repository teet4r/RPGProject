using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuButtons : MonoBehaviour
{
    // �ۼ��� : �����
    // 22.12.16 ���� ���ƶ�
    [SerializeField] GameObject optionWindow;

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
        LoadingProgress.LoadScene("InGame");
    }
    public void SelectOptionButton() //�� �ϳ��� ����ݱ� ����
    {
        optionWindow.SetActive(!optionWindow.activeSelf);
    }
    
    public void SelectGameExitButton()
    {
        Application.Quit();
    }
}