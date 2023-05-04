using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRotation : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] private InputManager input;

    [SerializeField] private Movement_2 move;

    private float Sensitivity;

    private Vector2 PlayerCameraControls;

    private float xRot;
    void Start()
    {
        Sensitivity = move.getSensitivity();
    }

    private void Update()
    {
        PlayerCameraControls = input.getPlayerCameraControls();
        dontMoveCamera();
    }

    private void dontMoveCamera()
    {
        transform.Rotate(0f, -PlayerCameraControls.x * Sensitivity / 2, 0f);
    }
}
