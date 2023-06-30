using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementV3 : MonoBehaviour
{
    private Vector3 PlayerMovementInput; //Used for displacing the character
    private Vector2 Movement; //used to convert vector2 into vector 3 for movement
    private Vector2 PlayerCameraControls;
    private float xRot;
    private float CurrentSprint;//used to check the current amount of sprint
    public bool isSprinting;
    public bool isMoving;
    public bool audioSprint;
    public bool noStaminaAudio;

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
    [SerializeField] private float Jumpforce;
    [SerializeField] private float sandalBoost;
    [SerializeField] private float invulnerabilityBoost;
    PlayerControls controls; //Controller Class

    private bool Invoked = false;

    //Calls while the script is being created
    private InputV2 input; //Moved all Inputs to this class.

    void Start()
    {
        //initiallizing sprint at the maximum
        CurrentSprint = MaxSprint;

        //gets controls from input manager
        input = GetComponent<InputV2>();

    }

    void Update()
    {
        //movement
        isSprinting = input.getisSprinting();
        PlayerCameraControls = input.getPlayerCameraControls();
        Movement = input.getMovement();
        PlayerMovementInput = new Vector3(Movement.x, 0f, Movement.y);

        MovePlayer();
        MoveCamera();
        Jump();
        PlayerStats.setMaxSprint(MaxSprint);
        PlayerStats.setSprint(CurrentSprint);
        getIsMoving();
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
            audioSprint = true;
        }
        else
        {
            audioSprint = false;
        }
        if (CurrentSprint <= 0.001f)
        {
            noStaminaAudio = true;
        }
        if (CurrentSprint >= MaxSprint)
        {
            noStaminaAudio = false;
        }

        if (PlayerStats.getInvincibilityState())
        {
            MoveVector *= invulnerabilityBoost;
        }

        //actually moves the player
        if (UsePowerup.sandalsActive())
        {
            MoveVector *= sandalBoost;
            if (!Invoked)
            {
                Invoked = true;
                Invoke("resetSandal", 30f);
            }
        }

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

    //code for Powerup resetting
    private void resetSandal()
    {
        UsePowerup.changeSandalBool();
        Invoked = false;
    }

    //code affects how the camera moves
    private void MoveCamera()
    {
        xRot -= PlayerCameraControls.y * Sensitivity / 2;
        transform.Rotate(0f, PlayerCameraControls.x * Sensitivity / 2, 0f);

        if (xRot + PlayerCamera.rotation.x < 90 && xRot + PlayerCamera.rotation.x > -90)
        {
            PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }
    }
    public void Jump()
    {
        if(Playerbody.velocity.y == 0)
        {
            if (input.getJump())
            {
                Playerbody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
            }
        }
        input.turnOffJump();
    }

    void getIsMoving()
    {

        if (Playerbody.velocity == Vector3.zero)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    public float getSensitivity()
    {
        return Sensitivity;
    }
}
