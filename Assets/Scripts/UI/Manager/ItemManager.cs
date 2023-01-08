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
    }

    private void Update()
    {
        CheckPotionCoolTime();
    }

    public void SetHpPotionUsableFalse()
    {
        hpPotionUsable = false;
        hpPotionCoolTime = 0f;
    }

    public void SetMpPotionUsableFalse()
    {
        mpPotionUsable = false;
        mpPotionCoolTime = 0f;
    }

    void CheckPotionCoolTime()
    {
        Debug.Log(hpPotionCoolTime);
        if (hpPotionCoolTime >= hpPotionCoolTimeMax) hpPotionUsable = true;
        if (mpPotionCoolTime >= mpPotionCoolTimeMax) mpPotionUsable = true;
        if (!hpPotionUsable && hpPotionCoolTime < hpPotionCoolTimeMax)
        {
            hpPotionCoolTime += Time.deltaTime / hpPotionCoolTimeMax;
        }
        if (!mpPotionUsable && mpPotionCoolTime < mpPotionCoolTimeMax)
        {
            mpPotionCoolTime += Time.deltaTime / mpPotionCoolTimeMax;
        }
        if (Inventory.instance.ItemSlots.activeSelf)
        {
            Inventory.instance.RefreshItemCoolTimeImage();
        }
    }

    [SerializeField] ItemContainer itemContainer;
    public ItemContainer ItemContainer { get { return itemContainer; } }
}