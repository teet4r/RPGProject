using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference movementControl;
    [SerializeField]
    private InputActionReference jumpControl;
    // [SerializeField]
    // private InputActionReference 


    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    //[SerializeField] private float dodge = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private CharacterController controller; //ĳ���� ���� ������Ʈ
    private Vector3 playerVelocity; // �÷��̾� �ӵ�
    private bool groundedPlayer;    //���� �÷��̾��?
    private Transform cameraMainTransform;

    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
    }


    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
    }




    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cameraMainTransform = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if(groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;

        }
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        move = (cameraMainTransform.forward* move.z) + (cameraMainTransform.right * move.x);
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        //������ ���� �÷��̾� ��ġ��ȭ
        if(move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if(jumpControl.action.triggered&&groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        //if(Input.GetKeyDown("Dodge")&&Input.GetgroundedPlayer)
       // {
         //   playerVelocity.z
        //}

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);




    }
}
