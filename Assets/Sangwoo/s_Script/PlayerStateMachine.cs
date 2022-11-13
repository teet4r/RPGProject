using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    CharacterController _characterController;
    Animator _animator;
    PlayerInput _playerInput;

    Vector2 _currentMovementInput;
    Vector3 _currentMovement;
    Vector3 _appliedMovement;
    bool _isMovementPressed;
    bool _isRunPressed;

    float _rotationFactorPerFramn = 15.0f;
    float _runMultiplier = 4.0f;
    int _zero = 0;

    bool _isJumpPressed = false;
    //float //221113



    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
