/*using UnityEngine;
using UnityEngine.AI;

public class BadGuyHealth : MonoBehaviour
{
    public int health;
    private int maxHealth = 100;


    void start() { }

    public void takeDamage (int amt)
    {
        health -= amt;
        if (health <= 0)
        {
            Destroy(gameObject);
            //other options could be temporary effects that slow down the monster bc idk if we want
            //to be able to kill it
        }
    }

}

public class MinotaurSenses : MonoBehaviour
{
    public float viewRadius, viewAngle;

    public LayerMask targetPlayer;
    public LayerMask obstacleMask;

    public gameObject player;

    public bool inSight;



    void Start()
    {

    }

    void Update()
    {
        Vector3 playTarget = (player.transform.position - transform.position).normalized;

        if (Vector3.Angle(transform.forward, playTarget) < viewAngle / 2)
        {
            float distanceToTarget = Vector3.distance(transform.position, player.transform.position);
            if (distanceToTarget < viewRadius)
            {
                if (Physics.Raycast(transform.position, playTarget, distanceToTarget, obstacleMask) == false)
                {
                    inSight = true;
                    MinotaurAI.ChasePlayer();
                }
            }
        }

    }
}



public class MinotaurAI : MonoBehaviour {
    public float minotaurSpeed = 6f;
    public float minotaurRotationSpeed = 8f;
    public float attackDistance = 5f;
    public float sightRange = 15f;

    public bool playerInAttackRange, playerinSight;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;




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

    private void start ()
    {
        player = gameObject.find("player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackDistance, whatIsPlayer);
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if(!MinotaurSenses.inSight && playerInSight)
        {
            playerinSight = false;
        }

        if (!playerInAttackRange && !playerInSight)
        {
            Roaming();
        }
        else if (playerinSight && !playerInAttackRange)
        {
            ChasePlayer();
        }
        else if (playerInAttackRange && playerinSight)
        {
            attackPlayer();
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

    private void attackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }

    private void resetAttack()
    {
        alreadyAttacked = false;
    }

    private float getWalkPoint()
    {
        float randomz = Random.Range(-walkPointRange, walkPointRange);
        float randomx = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z + randomz);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
}*/