using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // 작성자 : 김두현

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
        [SerializeField] Quest quest; // 퀘스트
        // [SerializeField] bool questStartable; // 퀘스트 시작 가능한지 여부 - 선행 퀘스트 완료 하였는지 체크
        [SerializeField] bool questComplete; // 퀘스트 완료 여부

        public bool CheckQuestStartable(int _questCode)
        {
            return false;
        }

        public void SetQuestStartable()
        {
        }
    }
}