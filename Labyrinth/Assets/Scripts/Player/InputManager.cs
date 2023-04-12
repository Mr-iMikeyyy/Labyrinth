using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInformation;

public class InputManager : MonoBehaviour
{
    PlayerControls controls; //Controller Class
    private bool isSprinting;
    private Vector2 Movement; //used to convert vector2 into vector 3 for movement
    private Vector2 PlayerCameraControls;
    private bool interact;
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

        //calls when button is pressed
        controls.Controls.InteractA.performed += ctx => interact = true;
        controls.Controls.InteractA.canceled += ctx => interact = false;

        //rotates the current item in player inventory
        controls.Controls.PowerupScrollLeft.performed += ctx => PlayerInventory.leftRotatePower();
        controls.Controls.PowerupScrollRight.performed += ctx => PlayerInventory.rightRotatePower();

        controls.Controls.UsePowerup.performed += ctx => usePowerup();
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


    public bool getisSprinting ()
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
        UsePowerup.activate();
        Debug.Log("working");
    }
}