using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOn : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData _pointer)
    {
        SoundManager.instance.sfxPlayer.Play(Sfx.MainMenuButtonMouse);
    }
}
