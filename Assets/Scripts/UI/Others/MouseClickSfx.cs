using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickSfx : MonoBehaviour
{
    void Update()
    {
        if (Cursor.lockState != CursorLockMode.Locked && Input.GetMouseButtonDown(0)) //����� -> ���콺 ��� ����, ���콺 ��Ȱ��ȭ
            SoundManager.instance.sfxPlayer.Play(Sfx.MouseClick);
    }
}
