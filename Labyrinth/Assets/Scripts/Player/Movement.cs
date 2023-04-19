using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;
    private float yRot;
    private float CurrentSprint;

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

    //Code for Jumping
    //[SerializeField] private float Jumpforce;

    // Checks if player is moving and/or sprinting
    public bool isMoving;
    public bool isSprinting; 
    public bool noStaminaAudio;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSprint = MaxSprint;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        //camera
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MoveCamera();

    }

    //code affects how the player moves
    private void MovePlayer()
    {
        //gets input and places it into a vector
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;

        //sprinting code
        if (Input.GetKey(KeyCode.LeftShift) && CurrentSprint > 0)
        {
            MoveVector *= SprintMultiplier;
            CurrentSprint -= SprintDrain;
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if(CurrentSprint == 0)
        {
            noStaminaAudio = true; 
        }
        else
        {
            noStaminaAudio = false;
        }

        //actually moves the player
        Playerbody.velocity = new Vector3(MoveVector.x, Playerbody.velocity.y, MoveVector.z);

        /* Jumping code
         if(Input.GetKeyDown(KeyCode.Space))
        {
            Playerbody.Addforce(Vector3.up * Jumpforce, Forcemode.Impulse);
        }
         */

         //  Check for Movement
        if(MoveVector != Vector3.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false; 
        }

        //Recovery Code
        if ((Playerbody.velocity == Vector3.zero && MaxSprint > CurrentSprint) && (SprintMode == 1 || SprintMode == 3))
        {
            CurrentSprint += SprintRec;
        }
        if ((!Input.GetKey(KeyCode.LeftShift) && CurrentSprint < MaxSprint) && (SprintMode == 2 || SprintMode == 3))
        {
            CurrentSprint += SprintRec;
        }
    }

    //code affects how the camera moves
    private void MoveCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

    }
}
