using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // �ۼ��� : �����

    public static QuestManager instance;

    [SerializeField] QuestInfo[] questInfos;

    public QuestInfo[] QuestInfos { get { return questInfos; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [System.Serializable]
    public class QuestInfo
    {
        [SerializeField] Quest quest; // ����Ʈ
        // [SerializeField] bool questStartable; // ����Ʈ ���� �������� ���� - ���� ����Ʈ �Ϸ� �Ͽ����� üũ
        [SerializeField] bool questComplete; // ����Ʈ �Ϸ� ����

        public bool CheckQuestStartable(int _questCode)
        {
            return false;
        }

        public void SetQuestStartable()
        {
        }
    }
}