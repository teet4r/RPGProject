using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] int itemNum;
    [SerializeField] Image itemNumImage;
    Image itemImage;
    Text itemNumText;
    private void Start()
    {
        itemImage = GetComponentsInChildren<Image>()[1];
        itemNumImage = GetComponentsInChildren<Image>()[2];
        SetItemNum(itemNum);
    }

    public void AddItemNum(int _num)
    {
        if (itemNum + _num <= item.BundleSize)
        {
            itemNum += _num;
        }
        else
        {
            itemNum = item.BundleSize;
        }
    }

    public void SetItemNum(int _num)
    {
        itemNum = _num;
        itemNumText.text = itemNum.ToString();
        if(itemNum==0)
        {
            ClearItemSlot();
        }
    }

    public void ClearItemSlot()
    {
        item = null;
        itemNum = 0;
        itemNumText.text = itemNum.ToString();
        itemNumText.gameObject.SetActive(false);
        itemImage.color = Color.clear;
    }

    public void SetItem(Item _item)
    {
        item = _item;
    }

    public void SetItemImageColor()
    {
        if (itemNum > 0)
        {
            itemImage.color = Color.white;
        }
        if(itemNum>1)
        {
            itemNumImage.gameObject.SetActive(true);
        }
    }
}