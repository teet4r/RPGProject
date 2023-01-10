using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestImgHeight : MonoBehaviour
{
    void Update()
    {
        RectTransform rectTransform = this.GetComponent<RectTransform>();
        int childNum = GetComponentsInChildren<Image>().Length;
        rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, childNum * 30);
        //Debug.Log(childNum);
    }
}
