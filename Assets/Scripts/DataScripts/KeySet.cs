using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

[CreateAssetMenu(fileName = "KeySet",menuName = "KeySet")]
public class KeySet : ScriptableObject
{
    [Header("Character Move Up/Down/Left/Right")]
    [SerializeField] KeyCode[] move = new KeyCode[KeyManager.moveSize]
        { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D }; // UP DOWN LEFT RIGHT
    public KeyCode MoveUp { get { return move[(int)KeyManager.MOVE.UP]; } }
    public KeyCode MoveDown { get { return move[(int)KeyManager.MOVE.DOWN]; } }
    public KeyCode MoveLeft { get { return move[(int)KeyManager.MOVE.LEFT]; } }
    public KeyCode MoveRight { get { return move[(int)KeyManager.MOVE.RIGHT]; } }

    [Header("Character Control")]
    [SerializeField] KeyCode[] characterControl = new KeyCode[KeyManager.characterControlSize]
        { KeyCode.Mouse0,KeyCode.LeftShift,KeyCode.LeftControl,KeyCode.Space };
    public KeyCode Attack { get { return characterControl[(int)KeyManager.CHARACTER_CONTROL.ATTACK]; } }
    public KeyCode Run { get { return characterControl[(int)KeyManager.CHARACTER_CONTROL.RUN]; } }
    public KeyCode Dash { get { return characterControl[(int)KeyManager.CHARACTER_CONTROL.DASH]; } }
    public KeyCode Jump { get { return characterControl[(int)KeyManager.CHARACTER_CONTROL.JUMP]; } }

    [Header("Normal Control")]
    [SerializeField] KeyCode[] normalControl = new KeyCode[KeyManager.normalControlSize]
        { KeyCode.F,KeyCode.Mouse1,KeyCode.Escape,KeyCode.I,KeyCode.P,KeyCode.K,KeyCode.J };
    public KeyCode Interaction { get { return normalControl[(int)KeyManager.NORMAL_CONTROL.INTERACTION]; } }
    public KeyCode SightRotation { get { return normalControl[(int)KeyManager.NORMAL_CONTROL.SIGHT_ROTATION]; } }
    public KeyCode Option { get { return normalControl[(int)KeyManager.NORMAL_CONTROL.OPTION]; } }
    public KeyCode Inventory { get { return normalControl[(int)KeyManager.NORMAL_CONTROL.INVENTORY]; } }
    public KeyCode CharacterInfo { get { return normalControl[(int)KeyManager.NORMAL_CONTROL.CHARACTER_INFO]; } }
    public KeyCode Skill { get { return normalControl[(int)KeyManager.NORMAL_CONTROL.SKILL]; } }
    public KeyCode Quest { get { return normalControl[(int)KeyManager.NORMAL_CONTROL.QUEST]; } }

    [Header("Quick Slot")]
    [SerializeField] KeyCode[] potionSlots = new KeyCode[4] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
    [SerializeField] KeyCode[] skillSlots = new KeyCode[4] { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.E };
    public KeyCode[] PotionSlots { get { return potionSlots; } }
    public KeyCode[] SkillSlots { get { return SkillSlots; } }
}