using UnityEngine;
using UnityEngine.AI;





public class MinosAI : MonoBehaviour {

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public MinosSenses senses; 




    // TODO: Need to create methods, variables, and classes to handle any logic that would relate to the Minotaur programmed behaviour
    // Not sure on the best approach yet.

    //roaming
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //chasing


    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    private void Start ()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        senses = GetComponent<MinosSenses>();
    }

    private void Update()
    {
        if (!senses.GetInSight())
        {
            Roaming();
        }
        else if (senses.GetInSight() && !senses.GetInAttackRange())
        {
            ChasePlayer();
        }
        else if (senses.GetInSight() && senses.GetInAttackRange() && !alreadyAttacked)
        {
            AttackPlayer();
        }
        else {
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
        float randomz = Random.Range(-walkPointRange, walkPointRange);
        float randomx = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z + randomz);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
}