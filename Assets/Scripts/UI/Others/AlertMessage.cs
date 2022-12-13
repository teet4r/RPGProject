using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertMessage : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float moveSpeed;
    Color color;
    private void Start()
    {
        Destroy(this.gameObject, time);
        color = GetComponent<Text>().color;
    }
    private void Update()
    {
        GetComponent<RectTransform>().Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        GetComponent<Text>().color = color;
        color.a -= Time.deltaTime / time;
    }
}