using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterInfoWindowButtons : MonoBehaviour
{
    // 작성자 : 김두현
    public void SelectStat1AddButton()
    {
        // Player.instance.AddStat(int.Parse(EventSystem.current.currentSelectedGameObject.transform.parent.name.Split('_')[1]),1);
    }

    public void SelectStat10AddButton()
    {
        // Player.instance.AddStat(int.Parse(EventSystem.current.currentSelectedGameObject.transform.parent.name.Split('_')[1]),10);
    }

    public void SelectStat1SubButton()
    {
        // Player.instance.AddStat(int.Parse(EventSystem.current.currentSelectedGameObject.transform.parent.name.Split('_')[1]),-1);
    }

    public void SelectStatAllButton()
    {
        // Player.instance.AddStat(int.Parse(EventSystem.current.currentSelectedGameObject.transform.parent.name.Split('_')[1]),Player.instance.StatPoint);
    }
}