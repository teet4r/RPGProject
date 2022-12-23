using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingBtn : MonoBehaviour
{
    public Image SwitchImg;
    public Sprite WindowScreen;
    public Sprite FullScreen;
    public Dropdown resolutionDropdown;

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
            SwitchImg.sprite= FullScreen;
            SetFullscreen(true);
            Debug.Log("��ü��");
        }
        else
        {
            SwitchImg.sprite= WindowScreen;
            SetFullscreen(false);
            Debug.Log("â����");
        }
    }
    private void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
