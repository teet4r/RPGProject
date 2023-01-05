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
    PointerEventData pointer = new PointerEventData(EventSystem.current);
    List<RaycastResult> raycastResults = new List<RaycastResult>();
    void Start()
    {
        graphicRaycaster = GetComponent<GraphicRaycaster>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count <= 0 || raycastResults[0].gameObject.name != "TopBar") return;
            selectedTopBar = raycastResults[0].gameObject;
            selectedTopBar.transform.parent.transform.SetAsLastSibling();
            selectedUI = raycastResults[0].gameObject.transform.parent.GetComponent<RectTransform>();
            difference = selectedUI.position - Input.mousePosition;
            topBarSelected = true;
            raycastResults.Clear();
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