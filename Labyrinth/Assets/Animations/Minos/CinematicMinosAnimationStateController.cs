using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicMinosAnimationStateController : MonoBehaviour
{

    Animator animator;
    CinematicMinosAI aI;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        aI = GetComponent<CinematicMinosAI>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking", aI.isWalking);
        animator.SetBool("isAttacking", aI.isAttacking);
        animator.SetBool("isChasing", aI.isChasing);
    }
}
