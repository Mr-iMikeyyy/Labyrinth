using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputV2 : MonoBehaviour
{
    PlayerControls controls; //Controller Class
    public bool isSprinting;
    public bool isMoving;
    private Vector2 Movement; //used to convert vector2 into vector 3 for movement
    private Vector2 PlayerCameraControls;
    private bool isJumping = false;
    private bool interact;
    //Calls while the script is being created
    void Awake()
    {
        controls = new PlayerControls();
        //calls when either sprint or the right or left triggers are used
        controls.ControlsV2.Sprint.performed += ctx => isSprinting = true;
        //calls when the above function is not used
        controls.ControlsV2.Sprint.canceled += ctx => isSprinting = false;

        //calls when wasd is used or left thumbstick is used
        controls.ControlsV2.Movement.performed += ctx => Movement = ctx.ReadValue<Vector2>();
        //calls when the above function is not used
        controls.ControlsV2.Movement.canceled += ctx => Movement = Vector2.zero;

        //calls when the right thumbstick or the mouse is moved
        controls.ControlsV2.Camera.performed += ctx => PlayerCameraControls = ctx.ReadValue<Vector2>();
        //calls when the above function is not used
        controls.ControlsV2.Camera.canceled += ctx => PlayerCameraControls = Vector2.zero;

        //calls when button is pressed
        controls.ControlsV2.InteractA.performed += ctx => interact = true;
        controls.ControlsV2.InteractA.canceled += ctx => interact = false;

        //rotates the current item in player inventory
        controls.ControlsV2.PowerupScrollLeft.performed += ctx => PlayerInventory.leftRotatePower();
        controls.ControlsV2.PowerupScrollRight.performed += ctx => PlayerInventory.rightRotatePower();

        controls.ControlsV2.UsePowerup.performed += ctx => usePowerup();

        controls.ControlsV2.JumpSpace.performed += ctx => isJumping = true;
    }


    //enables the control map
    void OnEnable()
    {
        controls.ControlsV2.Enable();
    }

    //disables the map
    void OnDisable()
    {
        controls.ControlsV2.Disable();
    }



    public bool getisSprinting()
    {
        return isSprinting;
    }

    public Vector2 getMovement()
    {
        return Movement;
    }

    public Vector2 getPlayerCameraControls()
    {
        return PlayerCameraControls;
    }

    public bool getInteract()
    {
        return interact;
    }

    public void usePowerup()
    {
        PlayerInventory.ActivatePowerup();
    }

    public bool getJump()
    {
        return isJumping;
    }

    public void turnOffJump()
    {
        isJumping = false;
    }
}
