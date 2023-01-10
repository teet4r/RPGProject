using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickSfx : MonoBehaviour
{
    void Update()
    {
        if (Cursor.lockState != CursorLockMode.Locked && Input.GetMouseButtonDown(0)) //락모드 -> 마우스 가운데 고정, 마우스 비활성화
            SoundManager.instance.sfxPlayer.Play(Sfx.MouseClick);
    }
}
