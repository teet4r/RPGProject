using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TopBarMoving : MonoBehaviour
{
    private GraphicRaycaster graphicRaycaster;
    Vector3 topBarLeftUp, topBarRightDown, difference;
    RectTransform selectedUI;
    GameObject selectedTopBar;
    bool topBarSelected = false;
    void Start()
    {
        graphicRaycaster = GetComponent<GraphicRaycaster>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ped = new PointerEventData(null);
            ped.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            graphicRaycaster.Raycast(ped, results);
            if (results.Count <= 0 || results[0].gameObject.name != "TopBar") return;
            selectedTopBar = results[0].gameObject;
            selectedTopBar.transform.parent.transform.SetAsLastSibling();
            selectedUI = results[0].gameObject.transform.parent.GetComponent<RectTransform>();
            difference = selectedUI.position - Input.mousePosition;
            topBarSelected = true;
            results.Clear();
        }
        else if (Input.GetMouseButton(0) && topBarSelected)
        {
            selectedUI.position = Input.mousePosition + difference;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectedTopBar = null;
            selectedUI = null;
            topBarSelected = false;
        }
    }
}