using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestWindow : MonoBehaviour
{
    private void OnEnable()
    {
        QuestManager.instance.ActivateQuestInfoGroup(false);
    }
}