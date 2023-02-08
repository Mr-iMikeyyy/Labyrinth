using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;
    private float yRot;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody Playerbody;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;
    //Code for Jumping
    //[SerializeField] private float Jumpforce;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        Playerbody.velocity = new Vector3(MoveVector.x, Playerbody.velocity.y, MoveVector.z);

        /* Jumping code
         if(Input.GetKeyDown(Keycode.Space))
        {
            Playerbody.Addforce(Vector3.up * Jumpforce, Forcemode.Impulse);
        }
         */
    }

    //code affects how the camera moves
    private void MoveCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

    }
}
