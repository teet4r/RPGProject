using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeySet",menuName = "KeySet")]
public class KeySet : ScriptableObject
{
    // 작성자 : 김두현
    [Header("Character Move Up/Down/Left/Right")]
    [SerializeField] KeyCode[] move = new KeyCode[KeyManager.moveSize]
        { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D }; // UP DOWN LEFT RIGHT
    public KeyCode[] Move { get { return move; } }

    [Header("Character Control")]
    [SerializeField] KeyCode[] characterControl = new KeyCode[KeyManager.characterControlSize]
        { KeyCode.Mouse0,KeyCode.LeftShift,KeyCode.LeftControl,KeyCode.Space };
    public KeyCode[] CharacterControl { get { return characterControl; } }

    [Header("Normal Control")]
    [SerializeField] KeyCode[] normalControl = new KeyCode[KeyManager.normalControlSize]
        { KeyCode.F,KeyCode.Mouse1,KeyCode.Escape,KeyCode.I,KeyCode.P,KeyCode.K,KeyCode.J };
    public KeyCode[] NormalControl { get { return normalControl; } }
    [Header("Quick Slot")]
    [SerializeField] KeyCode[] potionSlots = new KeyCode[4] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
    [SerializeField] KeyCode[] skillSlots = new KeyCode[4] { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.E };
    public KeyCode[] PotionSlots { get { return potionSlots; } }
    public KeyCode[] SkillSlots { get { return skillSlots; } }

    public void SetKey(KeyCode[] _move, KeyCode[] _char, KeyCode[] _norm, KeyCode[] _potion, KeyCode[] _skill)
    {
        move = _move;
        characterControl = _char;
        normalControl = _norm;
        potionSlots = _potion;
        skillSlots = _skill;
    }
}