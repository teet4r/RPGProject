using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    [SerializeField] Image MiniMap;
    [SerializeField] GameObject Quest;
    public Image MiniMapSwitchImg;
    public Image QuestSwitchImg;
    public Sprite CloseImg;
    public Sprite OpenImg;
    GameObject questGroup;

    void Awake()
    {
        // questGroup = Quest.transform.parent.gameObject;
    }

    public void MiniMapToggle(Toggle toggle)
    {
        if(toggle.isOn) 
        {
            MiniMapSwitchImg.sprite = CloseImg;
            MiniMap.gameObject.SetActive(true);

            // questGroup�� ��ġ�� �޾ƿ�
            var questPosition = questGroup.transform.position;
            // questGroup�� �� ��ġ�� ������ ��ġ�� ����
            var newPosition = new Vector3(
                questPosition.x,
                questPosition.y - MiniMap.rectTransform.rect.height,
                questPosition.z
            );
            questGroup.transform.position = newPosition;
        }
        else
        {
            MiniMapSwitchImg.sprite = OpenImg;
            MiniMap.gameObject.SetActive(false);

            var questPosition = questGroup.transform.position;
            var newPosition = new Vector3(
                questPosition.x,
                questPosition.y + MiniMap.rectTransform.rect.height,
                questPosition.z
            );
            questGroup.transform.position = newPosition;
        }
    }
    public void QuestToggle(Toggle toggle)
    {
        if (toggle.isOn)
        {
            QuestSwitchImg.sprite = CloseImg;
            Quest.gameObject.SetActive(true);
        }
        else
        {
            QuestSwitchImg.sprite = OpenImg;
            Quest.gameObject.SetActive(false);
        }
    }
}
