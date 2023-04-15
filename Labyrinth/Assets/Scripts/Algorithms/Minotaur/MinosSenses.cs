using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinosSenses : MonoBehaviour
{
    private float viewRadius = 15f;
    private float viewAngle = 45f;

    private LayerMask targetPlayer;
    private LayerMask obstacleMask;

    private GameObject player;

    [SerializeField] float attackRange = 2f;

    private bool inSight = false;
    private bool inAttackRange = false;

    void Start()
    {
        player = GameObject.Find("Player");
        System.Console.WriteLine(player);
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
