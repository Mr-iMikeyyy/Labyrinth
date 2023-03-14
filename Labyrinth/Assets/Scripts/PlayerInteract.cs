using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    // Start is called before the first frame update
    InputManager input;
    void Start()
    {
        input = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //creates a ray shooting foward in middle of camera
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        //shows the ray in debug
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; //used to gain info on hit
        //checks if raycast hits something and changes hitInfo variable.
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable obj = hitInfo.collider.GetComponent<Interactable>();
                if (input.getInteract())
                {

                    //activates the interaction
                    obj.BaseInteract();
                }
            }
        }
    }
}
