using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinosAnimationStateController : MonoBehaviour
{

    Animator animator;
    MinosAI aI;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        aI = GetComponent<MinosAI>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking", aI.isWalking);
        animator.SetBool("isAttacking", aI.isAttacking);
        animator.SetBool("isChasing", aI.isChasing);
        if (animator.GetBool("isAttacking")) {
            
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
                animator.SetBool("isChasing", true);
                animator.SetBool("isAttacking", false);
            }
            else {
                animator.SetBool("isChasing", false);
            }
        }
        
    }
}
