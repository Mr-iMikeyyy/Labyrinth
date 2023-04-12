using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinosSenses : MonoBehaviour
{
    public float viewRadius, viewAngle;

    public LayerMask targetPlayer;
    public LayerMask obstacleMask;

    public GameObject player;

    [SerializeField] float attackRange = 2f;

    private bool inSight = false;
    private bool inAttackRange = false;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 playTarget = (player.transform.position - transform.position).normalized;

        if (Vector3.Angle(transform.forward, playTarget) < viewAngle / 2)
    {
        float distanceToTarget = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToTarget < viewRadius)
        {
            if (Physics.Raycast(transform.position, playTarget, distanceToTarget, obstacleMask) == false)
            {
                inSight = true;

                if (distanceToTarget < attackRange)
                {
                    inAttackRange = true;
                }
                else
                {
                    inAttackRange = false;
                }
            }
            else
            {
                inSight = false;
                inAttackRange = false;
            }
        }
        else
        {
            inSight = false;
            inAttackRange = false;
        }
    }
    else
    {
        inSight = false;
        inAttackRange = false;
    }
}
    public bool GetInSight() {
        return inSight;
    }

    public bool GetInAttackRange() {
        return inAttackRange;
    }
}
