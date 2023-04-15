using UnityEngine;
using UnityEngine.AI;

public class MinosAI : MonoBehaviour {

    private NavMeshAgent agent;
    private Transform player;
    private MinosSenses senses; 

    private NavMeshBuilder builder;




    // TODO: Need to create methods, variables, and classes to handle any logic that would relate to the Minotaur programmed behaviour
    // Not sure on the best approach yet.

    //roaming
    private Vector3 walkPoint;
    private bool walkPointSet = false;

    //chasing


    //attacking
    private float timeBetweenAttacks = 1f;
    private bool alreadyAttacked = false;

    private void Start ()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        senses = GetComponent<MinosSenses>();
        builder = GameObject.Find("Floor").GetComponent<NavMeshBuilder>();
        getWalkPoint();
        agent.SetDestination(walkPoint);
    }

    private void Update()
    {
        if (!senses.GetInSight())
        {
            // Debug.Log("1");
            Roaming();
        }
        else if (senses.GetInSight() && !senses.GetInAttackRange())
        {
            // Debug.Log("2");
            ChasePlayer();
        }
        else if (senses.GetInSight() && senses.GetInAttackRange() && !alreadyAttacked)
        {
            // Debug.Log("3");
            AttackPlayer();
        }
        else {
            // Debug.Log("4");
            ChasePlayer();
        }
    }

    private void ChasePlayer() {
        // The Minotaur should be slightly faster than the player
        agent.SetDestination(player.position);
            
    }

    private void Roaming()
    {
        if (!walkPointSet)
        {
            getWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke("resetAttack", timeBetweenAttacks);
        }
    }

    private void resetAttack()
    {
        alreadyAttacked = false;
    }

    private void getWalkPoint()
    {
        walkPoint = builder.RandomNavmeshLocation(4f);
        walkPointSet = true;
    }
}