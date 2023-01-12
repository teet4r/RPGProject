using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    [SerializeField] GameObject questTitleImage;

    public void CreateQuickQuestInfo(QuestManager.QuestInfo _questInfo)
    {
        GameObject _questTitleImage = Instantiate(questTitleImage, Vector3.zero, Quaternion.identity, transform);
        _questTitleImage.GetComponent<QuestTitleImage>().CreateQuestTextImage(_questInfo);
    }
}