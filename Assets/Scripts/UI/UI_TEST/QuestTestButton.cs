using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTestButton : MonoBehaviour
{
    public void SelectButton(int num)
    {
        QuestManager.instance.StartQuest(num);
    }
}