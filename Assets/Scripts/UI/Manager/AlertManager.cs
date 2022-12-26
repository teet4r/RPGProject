using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertManager : MonoBehaviour
{
    // 작성자 : 김두현

    public static AlertManager instance;

    [SerializeField] GameObject alertMessage;
    [SerializeField] GameObject alertPosition;

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
        GameObject message = Instantiate(alertMessage, alertPosition.transform.position, Quaternion.identity, transform);
        message.GetComponent<Text>().text = _message;
    }
}