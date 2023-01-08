using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    [SerializeField] Text TalkText;
    [SerializeField] Text NpcName;
    private string writerTalk = "";

    void Start()
    {
        StartCoroutine(TestTalk());
    }
    IEnumerator TestTalk()
    {
        yield return StartCoroutine(TextEffect("장로", "아 졸린거같기도 하고 아닌거같기도 하고 이걸 우야면 좋누..."));
    }

    IEnumerator TextEffect(string Name, string Talk)
    {
        NpcName.text = Name;
        writerTalk = "";

        for(int i=0; i<Talk.Length; i++) //텍스트 타이핑 효과
        {
            writerTalk+= Talk[i];
            TalkText.text = writerTalk;
            yield return null;
        }
    }
}
