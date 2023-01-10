using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestListHeight : MonoBehaviour
{
    [SerializeField]
    GameObject TxtLayout;
    void Update()
    {
        RectTransform rectTransform = this.GetComponent<RectTransform>();
        int ChildNum = TxtLayout.GetComponentsInChildren<Image>().Length; //TxtLayout�� �ڽĵ� �� Image ���۳�Ʈ && setActive==true�� ����
        float width = rectTransform.rect.width;
        float newHeight = (ChildNum + 1) * 30;
        Debug.Log(ChildNum);
        //Debug.Log("Height" + height);
        rectTransform.sizeDelta = new Vector2(width, newHeight);
        //Debug.Log(newHeight);
    }
}
