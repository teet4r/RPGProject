using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

[CreateAssetMenu(fileName = "KeySet",menuName = "KeySet")]
public class KeySet : ScriptableObject
{
    public enum MOVE_CODE { UP, DOWN, LEFT, RIGHT }

    [Header("Character Move Up/Down/Left/Right")]
    [SerializeField] KeyCode[] move = new KeyCode[4] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D }; // up down left right

    [Header("Character Control")]
    [SerializeField] KeyCode attack = KeyCode.Mouse0;
    [SerializeField] KeyCode run = KeyCode.LeftControl;
    [SerializeField] KeyCode dash = KeyCode.LeftShift;
    [SerializeField] KeyCode jump = KeyCode.Space;

    [Header("Normal Control")]
    [SerializeField] KeyCode interaction = KeyCode.F;
    [SerializeField] KeyCode sightRotation = KeyCode.Mouse1;
    [SerializeField] KeyCode option = KeyCode.Escape; // optionWindow + closeWindow
    [SerializeField] KeyCode inventory = KeyCode.I;
    [SerializeField] KeyCode characterInfo = KeyCode.P;
    [SerializeField] KeyCode skill = KeyCode.K;
    [SerializeField] KeyCode quest = KeyCode.O;

    [Header("Quick Slot")]
    [SerializeField] KeyCode[] potionSlots = new KeyCode[4] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
    [SerializeField] KeyCode[] skillSlots = new KeyCode[4] { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.E };
}