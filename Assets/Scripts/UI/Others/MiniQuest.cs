using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniQuest : MonoBehaviour
{
    [SerializeField]
    GameObject TxtLayout;

    public void ChildSize()
    {
        int ChildNum = TxtLayout.transform.childCount;
        //Debug.Log(ChildNum);
    }
}
