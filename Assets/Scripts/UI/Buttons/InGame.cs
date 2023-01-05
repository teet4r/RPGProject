using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    [SerializeField] GameObject MiniMap;
    [SerializeField] GameObject Quest;
    public void MiniMapToggle(Toggle toggle)
    {
        if(toggle.isOn) 
        {
            MiniMap.SetActive(true);
        }
        else
        {
            MiniMap.SetActive(false);
        }
    }
    public void QuestToggle(Toggle toggle)
    {
        if (toggle.isOn)
        {
            Quest.SetActive(true);
        }
        else
        {
            Quest.SetActive(false);
        }
    }

}
