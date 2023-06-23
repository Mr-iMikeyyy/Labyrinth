using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinosSenses : MonoBehaviour
{
    private float viewRadius = 15f;
    private float viewAngle = 90f;

    private float calmingTime = 0;
    private float maximumcalmingtime = 5;

    private LayerMask targetPlayer;
    private LayerMask obstacleMask;

    private GameObject player;

    [SerializeField] float attackRange;

    private bool inSight = false;
    private bool inAttackRange = false;
    private bool chasing = false;

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
                    chasing = true;
                    calmingTime = 0;

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
                    chasing = false;
                    inAttackRange = false;
                }
            }
            else
            {
                chasing = false;
                inAttackRange = false;
            }
        }
        else
        {
            chasing = false;
            inAttackRange = false;
        }

        if (inSight == true && chasing == false)
        {
            calmingTime += Time.deltaTime;
            if (calmingTime > maximumcalmingtime)
            {
                inSight = false;
            }
        }
    }
    public bool GetInSight() {
        return inSight;
    }

    public bool GetInAttackRange() {
        return inAttackRange;
    }
}
