using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffSlot : MonoBehaviour
{
    [SerializeField] Image buffImage;
    [SerializeField] Image buffDurationImage;
    [SerializeField] Text buffDurationText;
    [SerializeField] float buffDuration;
    [SerializeField] float buffDurationLeft;


    private void Start()
    {
        Invoke("RefreshBuff", Time.deltaTime);
    }

    IEnumerator RefreshBuff()
    {
        while (true)
        {
            buffDurationLeft -= 0.5f;
            buffDurationImage.fillAmount = 1f - (buffDurationLeft / buffDuration);
            buffDurationText.text = buffDuration.ToString() + 's';
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void SetBuff(ConsumableItem _item)
    {
        buffDuration = _item.Duration;
        buffDurationLeft = _item.Duration;
        buffImage.sprite = _item.ItemImage;
        buffDurationImage.fillAmount = 0f;
        buffDurationText.text = buffDurationLeft.ToString() + 's';
    }

    void ClearBuff()
    {
        buffDuration = buffDurationLeft = 0f;
        buffImage.sprite = null;
        buffDurationImage.fillAmount = 1f;
        buffDurationText.text = "";
    }
}