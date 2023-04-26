using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class MinosAI : MonoBehaviour {
    private Transform player;
    private MinosSenses senses; 
    private NavMeshAgent agent;
    public bool isWalking;
    public bool isChasing;
    public bool isAttacking;




    // TODO: Need to create methods, variables, and classes to handle any logic that would relate to the Minotaur programmed behaviour
    // Not sure on the best approach yet.

    //roaming
    private Vector3 walkPoint;
    private bool walkPointSet = false;

    //chasing


    //attacking
    private float timeBetweenAttacks = 1f;
    private bool alreadyAttacked = false;

    //workaround for getting stuck on corners
    private float timeBetweenLast = 0f;
    private Vector3 currentloc = new Vector3(0,0,0);
    private Vector3 previousloc = new Vector3(0, 0, 0);


    private void Start ()
    {
        player = GameObject.Find("Player").transform;
        senses = GetComponent<MinosSenses>();
        agent = GetComponent<NavMeshAgent>();

        getWalkPoint();
        agent.SetDestination(walkPoint);
    }

    private void Update()
    {
        if (alreadyAttacked) {
            FollowPlayer();
        }
        else if (!senses.GetInSight())
        {
            // Debug.Log("1");
            Roaming();
        }
        else if (senses.GetInSight() && !senses.GetInAttackRange())
        {
            // Debug.Log("2");
            ChasePlayer();
        }
        else if (senses.GetInSight() && senses.GetInAttackRange())
        {
            Debug.Log("3");
            AttackPlayer();
        }
        previousloc = currentloc;
        currentloc = transform.position;
        if (currentloc == previousloc)
        {
            timeBetweenLast += Time.deltaTime;
        }
        if (timeBetweenLast >= .5f)
        {
            timeBetweenLast = 0;
            getWalkPoint();
            Roaming();
        }
    }

    

    private void ChasePlayer() {
        
        // The Minotaur should be slightly faster than the player
        agent.speed = 6f;

        isChasing = true;
        isAttacking = false;
        isWalking = false;
        transform.LookAt(player);
        agent.SetDestination(player.position);
            
    }

    private void Roaming()
    {
        agent.speed = 3f;
        isWalking = true;
        isAttacking = false;
        isChasing = false;

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
        Debug.Log("Stopping distance: " + agent.stoppingDistance);
        isWalking = false;
        isChasing = false;
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            isAttacking = true;
            alreadyAttacked = true;
            Invoke("resetAttack", timeBetweenAttacks);
        }
    }

    private void resetAttack()
    {
        isAttacking=false;
        alreadyAttacked = false;
        isChasing = true;
    }

    private void FollowPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
    }

    private void getWalkPoint()
    {
        walkPoint = RandomNavmeshLocation(50f);
        walkPointSet = true;
    }
    public Vector3 RandomNavmeshLocation(float radius) {
        Vector3 finalPosition = Vector3.zero;
        while (finalPosition == Vector3.zero) {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, radius, 1); 
            finalPosition = hit.position;            
            
        }
        return finalPosition;
    }
}