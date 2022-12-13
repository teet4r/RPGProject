using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertManager : MonoBehaviour
{
    // 작성자 : 김두현

    public static AlertManager instance;

    [SerializeField] GameObject alertMessage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ShowAlert(string _message)
    {
        GameObject message = Instantiate(alertMessage, Vector3.zero, Quaternion.identity, transform);
        message.GetComponent<Text>().text = _message;
    }
}