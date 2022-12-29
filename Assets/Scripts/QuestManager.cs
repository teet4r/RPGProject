using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // �ۼ��� : �����

    public static QuestManager instance;

    [SerializeField] QuestInfo[] questInfos;
    [SerializeField] Sprite[] questIcons;

    public QuestInfo[] QuestInfos { get { return questInfos; } }
    public Sprite[] QuestIcons { get { return questIcons; } }

    public enum ICON_TYPE { MAIN, SUB }

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