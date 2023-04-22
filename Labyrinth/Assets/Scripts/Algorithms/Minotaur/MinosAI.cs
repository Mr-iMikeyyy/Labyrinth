using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class MinosAI : MonoBehaviour {
    private Transform player;
    private MinosSenses senses; 

    [SerializeField] GameObject navMesh;
    private NavMeshSurface surface;
    private NavMeshAgent agent;




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
        senses = GetComponent<MinosSenses>();
        surface = navMesh.GetComponent<NavMeshSurface>();
        agent = GetComponent<NavMeshAgent>();

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
        walkPoint = RandomNavmeshLocation(16f);
        walkPointSet = true;
    }
    public Vector3 RandomNavmeshLocation(float radius) {
        Vector3 finalPosition = Vector3.zero;
        while (finalPosition == Vector3.zero) {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += transform.position;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
                finalPosition = hit.position;            
            }
        }
        return finalPosition;
    }
}