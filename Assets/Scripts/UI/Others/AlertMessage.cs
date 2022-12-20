using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertMessage : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float moveSpeed;
    Color color;
    float[] colorSub = new float[4];
    [SerializeField] Color purColor;
    private void Start()
    {
        Destroy(this.gameObject, time);
        color = GetComponent<Text>().color;
        colorSub[0] = purColor.a - color.a;
        colorSub[1] = purColor.r - color.r;
        colorSub[2] = purColor.g - color.g;
        colorSub[3] = purColor.b - color.b;
    }
    private void Update()
    {
        GetComponent<RectTransform>().Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        GetComponent<Text>().color = color;
        color.a += Time.deltaTime / time * colorSub[0];
        color.r += Time.deltaTime / time * colorSub[1];
        color.g += Time.deltaTime / time * colorSub[2];
        color.b += Time.deltaTime / time * colorSub[3];
    }
}