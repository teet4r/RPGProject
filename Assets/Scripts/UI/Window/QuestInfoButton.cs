using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfoButton : MonoBehaviour
{
    [SerializeField] Text questTitle;
    [SerializeField] Image questImage;
    public void SetButton(string _title, bool _isMain)
    {
        questTitle.text = _title;
        if (_isMain) questImage.sprite = QuestManager.instance.QuestIcons[(int)QuestManager.ICON_TYPE.MAIN];
        else questImage.sprite = QuestManager.instance.QuestIcons[(int)QuestManager.ICON_TYPE.SUB];
    }

    public void SelectButton()
    {

    }
}
