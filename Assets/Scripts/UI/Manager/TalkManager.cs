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
        yield return StartCoroutine(TextEffect("���", "�� �����Ű��⵵ �ϰ� �ƴѰŰ��⵵ �ϰ� �̰� ��߸� ����..."));
    }

    IEnumerator TextEffect(string Name, string Talk)
    {
        NpcName.text = Name;
        writerTalk = "";

        for(int i=0; i<Talk.Length; i++) //�ؽ�Ʈ Ÿ���� ȿ��
        {
            writerTalk+= Talk[i];
            TalkText.text = writerTalk;
            yield return null;
        }
    }
}
