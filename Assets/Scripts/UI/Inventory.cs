using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    // �ۼ��� : �����
    /* ������ ����, ������ ���� � ������ ������ �� ����
     * 
     */

    public static Inventory instance;

    [SerializeField] GameObject itemTabGroup;

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

    public int HowManyItem(Item _item)
    {
        int num = 0;
        for (int i = 0; i < itemTabGroup.transform.childCount; i++)
        {
            for (int j = 0; j < itemTabGroup.transform.GetChild(i).childCount; j++)
            {
                if (itemTabGroup.transform.GetChild(i).GetChild(j).GetComponent<ItemSlot>().Item == _item)
                {
                    num += itemTabGroup.transform.GetChild(i).GetChild(j).GetComponent<ItemSlot>().ItemNum;
                }
            }
        }
        return num;
    }
}