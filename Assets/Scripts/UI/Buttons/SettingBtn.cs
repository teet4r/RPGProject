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
        resolutionDropdown.ClearOptions(); //��Ӵٿ� �ʱ�ȭ

        int currentResolutionIndex = 0;
        List<string> options = new List<string>(); //���ο� ��Ʈ�� �ɼ� �߰�
        for(int i=0; i<resolutions.Length; i++) //resolutions �� ���̸�ŭ Ȯ��
        {
            string option = resolutions[i].width + "��" + resolutions[i].height;
            options.Add(option); //options �� option �߰�

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) //��ũ�� ���̿� �迭 ���� ���� �����鼭 ��ũ�� ����, �迭 �� ���� ���� ��
            {
                currentResolutionIndex = i; //i�� index ������ ��
            }
        }
        resolutionDropdown.AddOptions(options); //���ο� �ɼ� �߰�
        resolutionDropdown.value = currentResolutionIndex; //value ���� current ���� ����
        resolutionDropdown.RefreshShownValue(); //�� �Լ��� ���� �⺻�� �����ִ� ���� ����
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
