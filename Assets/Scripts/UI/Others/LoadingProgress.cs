using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingProgress : MonoBehaviour
{
    static string nextScene;
    public Text progressTxt;

    [SerializeField]
    Sprite[] loadImgs;
    [SerializeField]
    Image progressBar;
    [SerializeField]
    Image loadingScreenImg;
    [SerializeField]
    Text Txt;
    [SerializeField]
    string[] tipTxts; 

    void Start()
    {
        loadingScreenImg.sprite = loadImgs[Random.Range(0, loadImgs.Length)]; //loadingScreenImg의 이미지가 랜덤으로 출력되게 해주는 친구
        Txt.text = tipTxts[Random.Range(0, tipTxts.Length)];
        StartCoroutine(LoadSceneProgress());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadSceneProgress()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime / 3f; //나눈 초만큼 실행
                progressBar.fillAmount = Mathf.Lerp(0f, 1f, timer);
                if (timer > 1)
                {
                    timer = 1;
                }
                progressTxt.text = (timer*100).ToString("N0") +"%";

                if (progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
