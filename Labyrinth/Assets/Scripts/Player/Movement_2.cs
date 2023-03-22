using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_2 : MonoBehaviour
{
    private Vector3 PlayerMovementInput; //Used for displacing the character
    private Vector2 Movement; //used to convert vector2 into vector 3 for movement
    private Vector2 PlayerCameraControls;
    private float xRot;
    private float yRot;
    private float CurrentSprint;//used to check the current amount of sprint
    private bool isSprinting;

    [SerializeField] private Transform PlayerCamera; //Camera Object
    [SerializeField] private Rigidbody Playerbody; //Player Object
    [Space]
    [SerializeField] private float Speed; //Base Player Speed
    [SerializeField] private float Sensitivity; //Camera Sensitivity
    [Space]
    [Header("Sprint Settings")]
    [SerializeField] private float SprintMultiplier; //Multiplier for Sprinting
    [SerializeField] private float MaxSprint; //Maximum amount of sprint
    [SerializeField] private float SprintDrain; //amount sprint drains by per frame
    [SerializeField] private float SprintRec; //amount sprint recovers by not moving
    [Header("Sprint Recovery Mode")]
    [Header("0: No Recovery, 1: Not Moving, 2: Not sprinting, 3:Both")]
    [SerializeField] private int SprintMode; //Mode 1: when player is standing still, Mode 2: When player is not holding shift
                                             //Mode 3: Both are implemented, doubled boost when player is idle not holding shift.
    PlayerControls controls; //Controller Class

    //Calls while the script is being created
    void Awake()
    {
        controls = new PlayerControls();
        //calls when either sprint or the right or left triggers are used
        controls.Controls.Sprint.performed += ctx => isSprinting = true;
        //calls when the above function is not used
        controls.Controls.Sprint.canceled += ctx => isSprinting = false;

        //calls when wasd is used or left thumbstick is used
        controls.Controls.Movement.performed += ctx => Movement = ctx.ReadValue<Vector2>();
        //calls when the above function is not used
        controls.Controls.Movement.canceled += ctx => Movement = Vector2.zero;

        //calls when the right thumbstick or the mouse is moved
        controls.Controls.Camera.performed += ctx => PlayerCameraControls = ctx.ReadValue<Vector2>();
        //calls when the above function is not used
        controls.Controls.Camera.canceled += ctx => PlayerCameraControls = Vector2.zero;
    }
    

    //enables the control map
    void OnEnable()
    {
        controls.Controls.Enable();   
    }

    //disables the map
    void OnDisable()
    {
        controls.Controls.Disable();
    }

    void Start()
    {
        //initiallizing sprint at the maximum
        CurrentSprint = MaxSprint;
        PlayerStats.setMaxSprint(MaxSprint);
        PlayerStats.setSprint(CurrentSprint);
    }

    void Update()
    {
        //movement
        PlayerMovementInput = new Vector3(Movement.x, 0f, Movement.y);

        MovePlayer();
        MoveCamera();

        PlayerStats.setMaxSprint(MaxSprint);
        PlayerStats.setSprint(CurrentSprint);
    }

    //code affects how the player moves
    private void MovePlayer()
    {
        //gets input and places it into a vector
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;

        //sprinting code
        if (isSprinting && CurrentSprint > 0)
        {
            MoveVector *= SprintMultiplier;
            CurrentSprint -= SprintDrain;
        }

        //actually moves the player
        Playerbody.velocity = new Vector3(MoveVector.x, Playerbody.velocity.y, MoveVector.z);


        //Recovery Code
        if ((Playerbody.velocity == Vector3.zero && MaxSprint > CurrentSprint) && (SprintMode == 1 || SprintMode == 3))
        {
            CurrentSprint += SprintRec;
        }
        if ((!isSprinting && CurrentSprint < MaxSprint) && (SprintMode == 2 || SprintMode == 3))
        {
            CurrentSprint += SprintRec;
        }

    }

    //code affects how the camera moves
    private void MoveCamera()
    {
        xRot -= PlayerCameraControls.y * Sensitivity / 2;

        transform.Rotate(0f, PlayerCameraControls.x * Sensitivity / 2, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

    }

   
}
