using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    const float checkTime = 0.1f;
    const float hpPotionCoolTimeMax = 1.5f;
    const float mpPotionCoolTimeMax = 1.5f;

    [SerializeField] float hpPotionCoolTime;
    [SerializeField] float mpPotionCoolTime;
    [SerializeField] bool hpPotionUsable;
    [SerializeField] bool mpPotionUsable;

    public float HpPotionCoolTime { get { return hpPotionCoolTime; } }
    public float MpPotionCoolTime { get { return mpPotionCoolTime; } }
    public bool HpPotionUsable { get { return hpPotionUsable; } }
    public bool MpPotionUsable { get { return mpPotionUsable; } }

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
        hpPotionCoolTime = 0f;
        mpPotionCoolTime = 0f;
        hpPotionUsable = true;
        mpPotionUsable = true;

        StartCoroutine(CheckPotionCoolTIme());
    }

    public void SetHpPotionUsableFalse()
    {
        hpPotionUsable = false;
    }

    public void SetMpPotionUsableFalse()
    {
        mpPotionUsable = false;
    }

    IEnumerator CheckPotionCoolTIme()
    {
        while (true)
        {
            if (hpPotionCoolTime >= hpPotionCoolTimeMax) hpPotionUsable = true;
            if (mpPotionCoolTime >= mpPotionCoolTimeMax) mpPotionUsable = true;
            if (!hpPotionUsable)
            {
                hpPotionCoolTime -= checkTime;
            }
            if (!mpPotionUsable)
            {
                mpPotionCoolTime -= checkTime;
            }
            if (Inventory.instance.ItemSlots.activeSelf)
            {
                Inventory.instance.RefreshItemCoolTimeImage();
            }
            yield return new WaitForSeconds(checkTime);
        }
    }

    [SerializeField] ItemContainer itemContainer;
    public ItemContainer ItemContainer { get { return itemContainer; } }
}