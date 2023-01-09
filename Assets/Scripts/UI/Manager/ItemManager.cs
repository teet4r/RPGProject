using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    const float checkTime = 0.1f;
    const float consumableItemCoolTimeMax = 1.5f;

    float[] consumableItemCoolTime = new float[(int)ConsumableItem.CONSUMABLE_TYPE.ENUM_SIZE];
    bool[] consumableItemUsable = new bool[(int)ConsumableItem.CONSUMABLE_TYPE.ENUM_SIZE];

    public float ConsumableItemCoolTimeMax { get { return consumableItemCoolTimeMax; } }
    public float[] ConsumableItemCoolTime { get { return consumableItemCoolTime; } }
    public bool[] ConsumableItemUsable { get { return consumableItemUsable; } }

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

    private void Start()
    {
        for (int i = 0; i < consumableItemCoolTime.Length; i++)
        {
            consumableItemCoolTime[i] = 0f;
            consumableItemUsable[i] = true;
        }
        StartCoroutine(CheckConsumableItemCoolTime());
    }

    public void SetConsumableItemUsableFalse(int _idx)
    {
        consumableItemCoolTime[_idx] = 0f;
        consumableItemUsable[_idx] = false;
    }

    IEnumerator CheckConsumableItemCoolTime()
    {
        while (true)
        {
            for (int i = 0; i < consumableItemCoolTime.Length; i++)
            {
                if (consumableItemCoolTime[i] >= consumableItemCoolTimeMax)
                {
                    consumableItemUsable[i] = true;
                }
                if (!consumableItemUsable[i] && consumableItemCoolTime[i] < ConsumableItemCoolTimeMax)
                {
                    consumableItemCoolTime[i] += checkTime / ConsumableItemCoolTimeMax;
                }
            }
            if (Inventory.instance.ItemSlots.activeSelf)
            {
                for (int i = 0; i < (int)ConsumableItem.CONSUMABLE_TYPE.ENUM_SIZE; i++)
                {
                    Inventory.instance.RefreshItemCoolTimeImage((ConsumableItem.CONSUMABLE_TYPE)i);
                }
            }
            yield return new WaitForSeconds(checkTime);
        }
    }

    [SerializeField] ItemContainer itemContainer;
    public ItemContainer ItemContainer { get { return itemContainer; } }
}