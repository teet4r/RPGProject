using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestTitleImage : MonoBehaviour
{
    [SerializeField] GameObject textLayout;
    [SerializeField] GameObject textImage;
    bool check = false;
    QuestManager.QuestInfo questInfo;

    private void Start()
    {
        StartCoroutine(RefreshTextImage());
    }

    IEnumerator RefreshTextImage()
    {
        while (true)
        {
            if (check)
            {
                int _num = 0;
                for (int i = 0; i < questInfo.Quest.QuestRequireMonster.Length; i++)
                {
                    textLayout.transform.GetChild(i).GetComponent<QuestTextImage>().RefreshNumText($"{questInfo.MonsterKill[i]}/{questInfo.Quest.QuestRequireMonster[i].MonsterNum}");
                }
                for (int i = questInfo.Quest.QuestRequireMonster.Length; i < textLayout.transform.childCount; i++)
                {
                    textLayout.transform.GetChild(i).GetComponent<QuestTextImage>().RefreshNumText($"{Inventory.instance.HowManyItem(questInfo.Quest.QuestRequireItem[_num++].Item)}/{questInfo.Quest.QuestRequireItem[_num++].ItemNum}");
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void SetHeight()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, (textLayout.transform.childCount + 1) * 30f);
    }

    public void CreateQuestTextImage(QuestManager.QuestInfo _questInfo)
    {
        questInfo = _questInfo;
        GameObject _textImage;
        GetComponentInChildren<Text>().text = _questInfo.Quest.QuestTitle;
        for (int i = 0; i < _questInfo.Quest.QuestRequireMonster.Length; i++)
        {
            _textImage = Instantiate(textImage, Vector3.zero, Quaternion.identity, textLayout.transform);
            Debug.Log(_textImage.GetComponent<QuestTextImage>());
            _textImage.GetComponent<QuestTextImage>().SetText(
                $"{_questInfo.Quest.QuestRequireMonster[i].Monster.MonsterName} Åä¹ú",
                $"{_questInfo.MonsterKill[i]}/{_questInfo.Quest.QuestRequireMonster[i].MonsterNum}"
                );
        }
        for (int i = 0; i < _questInfo.Quest.QuestRequireItem.Length; i++)
        {
            _textImage = Instantiate(textImage, Vector3.zero, Quaternion.identity, textLayout.transform);
            _textImage.GetComponent<QuestTextImage>().SetText(
                $"{_questInfo.Quest.QuestRequireItem[i].Item.ItemName}",
                $"{Inventory.instance.HowManyItem(_questInfo.Quest.QuestRequireItem[i].Item)}/{_questInfo.Quest.QuestRequireItem[i].ItemNum}"
                );
        }
        check = true;
        SetHeight();
    }
}