using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionWindow : MonoBehaviour
{
    [SerializeField] Text interactionKeyText;
    [SerializeField] Text interactionNameText;
    [SerializeField] Text interactionInfoText;

    private void Start()
    {
        StartCoroutine(RefreshInteractionText());
    }

    IEnumerator RefreshInteractionText()
    {
        while(true)
        {
            interactionKeyText.text = $"{KeyManager.instance.Key(KeyManager.KEYNAME.NORM_INTERACTION)}";
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void SetInteractionWindow(GameObject _gameobject)
    {
        if (_gameobject.GetComponent<NpcObject>())
        {
            Npc _npc = _gameobject.GetComponent<NpcObject>().Npc;
            interactionNameText.text = _npc.NpcName;
            interactionInfoText.text = _npc.NpcInfo;
        }
        else
        {
            interactionNameText.text = "금 동상";
            interactionInfoText.text = "물건을 사고 팔 수 있다.";
        }
    }
}