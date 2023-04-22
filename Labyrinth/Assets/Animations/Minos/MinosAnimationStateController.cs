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
        
    }
}
