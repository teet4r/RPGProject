using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class SettingBtn : MonoBehaviour
{
    public Image SwitchImg;
    public Sprite WindowScreen;
    public Sprite FullScreen;
    public Dropdown resolutionDropdown;
    public GameObject KeySettingPanel;

    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions(); //드롭다운 초기화

        int currentResolutionIndex = 0;
        List<string> options = new List<string>(); //새로운 스트링 옵션 추가
        for(int i=0; i<resolutions.Length; i++) //resolutions 의 길이만큼 확인
        {
            string option = resolutions[i].width + "×" + resolutions[i].height;
            options.Add(option); //options 에 option 추가

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) //스크린 넓이와 배열 값의 넓이 같으면서 스크린 높이, 배열 값 높이 같을 때
            {
                currentResolutionIndex = i; //i가 index 값으로 들어감
            }
        }
        resolutionDropdown.AddOptions(options); //새로운 옵션 추가
        resolutionDropdown.value = currentResolutionIndex; //value 값에 current 값이 들어가고
        resolutionDropdown.RefreshShownValue(); //이 함수를 통해 기본값 보여주는 것이 가능
    }

    public void SwitchBtn(Toggle toggle)
    {
        if (toggle.isOn)
        {
            SoundManager.instance.sfxPlayer.Play(Sfx.ToggleButton);
            SwitchImg.sprite= FullScreen;
            SetFullscreen(true);
        }
        else
        {
            SoundManager.instance.sfxPlayer.Play(Sfx.ToggleButton);
            SwitchImg.sprite= WindowScreen;
            SetFullscreen(false);
        }
    }
    public void KeySettingPopUpButton()
    {
        SoundManager.instance.sfxPlayer.Play(Sfx.ButtonConfirm);
        KeySettingPanel.SetActive(!KeySettingPanel.activeSelf);
    }
    private void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
