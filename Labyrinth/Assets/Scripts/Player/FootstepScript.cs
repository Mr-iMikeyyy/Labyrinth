using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public AudioSource footstep;

    public AudioSource sprintFootstep;

    private Movement_2 movementScript;

    // Start is called before the first frame update
    void Start()
    {
        footstep.enabled = false;
        sprintFootstep.enabled = false;

        movementScript = GetComponent<Movement_2>();
    }

    // Update is called once per frame
 void Update()
    {
        if (movementScript.isMoving && !movementScript.isSprinting)
        {
            if (!footstep.enabled)
            {
                footstep.enabled = true;
            }
            if (sprintFootstep.enabled)
            {
                sprintFootstep.enabled = false;
            }
        }
        else if (movementScript.isMoving && movementScript.isSprinting)
        {
            if(!sprintFootstep.enabled)
            {
                sprintFootstep.enabled = true;
            }
            if (footstep.enabled)
            {
                footstep.enabled = false;
            }
        }
        else
        {
            if (footstep.enabled)
            {
                footstep.enabled = false;
            }

            if (sprintFootstep.enabled)
            {
                sprintFootstep.enabled = false;
            }
        }
    }
}







//     void Update()
//     {
//         if (movementScript.isMoving == true && movementScript.isSprinting == false)
//         {
//             footsteps();
//         }
//         else if (movementScript.isMoving == true && movementScript.isSprinting == true)
//         {
//             footsteps();
//         }
//         else
//         {
//             stopSteps();
//         }
//     }

//     void footsteps()
//     {
//         if (!footstep.isPlaying)
//         {
//             footstep.Play();
//         }
//     }

//     void stopSteps()
//     {
//         if (footstep.isPlaying)
//         {
//             footstep.Stop();
//         }
//     }
// }
