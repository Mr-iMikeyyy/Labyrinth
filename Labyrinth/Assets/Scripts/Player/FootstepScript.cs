using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public AudioSource footstep;

    public AudioSource sprintFootstep;

    public AudioSource runBreathing;

    public AudioSource noStamina;

    private Movement_2 movementScript;

    private bool isPlayingNoStaminaAudio = false;

    // Start is called before the first frame update
    void Start()
    {
        footstep.enabled = false;
        sprintFootstep.enabled = false;
        runBreathing.enabled = false;
        noStamina.enabled = false;

        movementScript = GetComponent<Movement_2>();
    }

    // Update is called once per frame
 void Update()
    {
        if (movementScript.isMoving && !movementScript.audioSprint)
        {
            if (!footstep.enabled)
            {
                footstep.enabled = true;
            }
            if (sprintFootstep.enabled)
            {
                sprintFootstep.enabled = false;
                runBreathing.enabled = false;
            }
        }
        else if (movementScript.isMoving && movementScript.audioSprint)
        {
            if(!sprintFootstep.enabled)
            {
                sprintFootstep.enabled = true;
                runBreathing.enabled = true;
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
                runBreathing.enabled = false;
            }
        }
        
        if(movementScript.noStaminaAudio && !isPlayingNoStaminaAudio)
        {
            noStamina.enabled = true;
            noStamina.Play();
            isPlayingNoStaminaAudio = true;
        }
        else if(!movementScript.noStaminaAudio && isPlayingNoStaminaAudio)
        {
            noStamina.enabled = false;
            isPlayingNoStaminaAudio = false;
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
