using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingBtn : MonoBehaviour
{
    public Image SwitchImg;
    public Sprite WindowScreen;
    public Sprite FullScreen;

    public void SwitchBtn(Toggle toggle)
    {
        if (toggle.isOn)
        {
            SwitchImg.sprite= WindowScreen;
        }
        else
        {
            SwitchImg.sprite= FullScreen;
        }
    }
}
