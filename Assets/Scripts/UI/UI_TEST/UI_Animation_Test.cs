using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Animation_Test : MonoBehaviour
{
    [SerializeField] float animationTime;
    RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        rect.localScale = Vector3.zero;
    }
    public IEnumerator PlayResizeBiggerAnimation()
    {
        while (true)
        {
            if (rect.localScale.x < 1f)
            {
                if (rect.localScale.x + Time.deltaTime / animationTime < 1f)
                {
                    rect.localScale += new Vector3(Time.deltaTime / animationTime, Time.deltaTime / animationTime, Time.deltaTime / animationTime);
                }
                else
                {
                    rect.localScale = Vector3.one;
                }
            }
            else
            {
                rect.localScale = Vector3.one;
                break;
            }
            yield return null;
        }
    }
    public IEnumerator PlayResizeSmallerAnimation()
    {
        while(true)
        {
            if (rect.localScale.x > 0f)
            {
                if (rect.localScale.x - Time.deltaTime / animationTime > 0f)
                {
                    rect.localScale -= new Vector3(Time.deltaTime / animationTime, Time.deltaTime / animationTime, Time.deltaTime / animationTime);
                }
                else
                {
                    rect.localScale = Vector3.zero;
                }
            }
            else
            {
                rect.localScale = Vector3.zero;
                gameObject.SetActive(false);
                break;
            }
            yield return null;
        }
    }
}