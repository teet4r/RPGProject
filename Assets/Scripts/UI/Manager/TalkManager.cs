using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    [SerializeField] Text TalkText;
    [SerializeField] Text NpcName;
    [SerializeField] PlayerInteraction playerInteraction;
    private string writerTalk = "";

    void Update()
    {
        StartCoroutine(TestTalk());
    }
    IEnumerator TestTalk()
    {
        yield return StartCoroutine(TextEffect(NpcName.text,TalkText.text));
    }

    IEnumerator TextEffect(string name, string what)
    {
        NpcName.text = playerInteraction.Npc.NpcName;
        var writerTalk = playerInteraction.Npc.Bigs;

        for(int i=0; i< writerTalk.Length; i++) //텍스트 타이핑 효과
        {
            TalkText.text += writerTalk[i];
            yield return null;
        }
    }
}
