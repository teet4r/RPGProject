using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    // 작성자 : 김두현
    [SerializeField] Item item;
    [SerializeField] int itemNum;
    [SerializeField] Image itemNumImage;
    Image itemImage;
    Text itemNumText;
    int reinforceLevel = 0;
    public Item Item { get { return item; } }
    public int ItemNum { get { return itemNum; } }
    public int ReinforceLevel { get { return reinforceLevel; } }

    // 20221111 17:26 열거형으로 슬롯타입 지정 및 변수 생성하고 Item과 연동할것

    private void Start()
    {
        itemImage = GetComponentsInChildren<Image>()[1];
        itemNumImage = GetComponentsInChildren<Image>()[2];
        itemNumText = GetComponentInChildren<Text>();
        if (item != null)
        {
            SetItemImage();
            SetItemNum(itemNum);
            SetItemImageColor();
        }
        else
        {
            ClearItemSlot();
        }
    }

    public void SetItemImage()
    {
        itemImage.sprite = item.ItemImage;
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
        if (itemNum == 0)
        {
            ClearItemSlot();
        }
        else if (itemNum == 1)
        {
            itemNumText.gameObject.SetActive(false);
            itemNumImage.gameObject.SetActive(false);
        }
        else if (itemNum > 1)
        {
            itemNumText.gameObject.SetActive(true);
            itemNumImage.gameObject.SetActive(true);
        }
        itemNum = _num;
        itemNumText.text = itemNum.ToString();
    }

    public void ClearItemSlot()
    {
        item = null;
        itemNum = 0;
        itemNumText.gameObject.SetActive(false);
        itemNumText.text = itemNum.ToString();
        itemNumImage.gameObject.SetActive(false);
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
        if (itemNum > 1)
        {
            itemNumImage.gameObject.SetActive(true);
        }
    }
}