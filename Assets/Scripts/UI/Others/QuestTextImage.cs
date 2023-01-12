using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTextImage : MonoBehaviour
{
    [SerializeField] Text questInfoText;
    [SerializeField] Text questNumText;

    public Text QuestInfoText { get { return questInfoText; } set { questInfoText = value; } }
    public Text QuestNumText { get { return questNumText; } set { questNumText = value; } }

    public void SetText(string _infoText, string _infoNumText)
    {
        Debug.Log("HI");
        questInfoText.text = _infoText;
        questNumText.text = _infoNumText;
    }

    public void RefreshNumText(string _infoNumText)
    {
        questNumText.text = _infoNumText;
    }
}