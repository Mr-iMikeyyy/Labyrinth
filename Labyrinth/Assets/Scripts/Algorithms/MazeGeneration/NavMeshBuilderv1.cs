using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBuilderv1 : MonoBehaviour
{
    // private NavMeshSurface navMesh;
    // private NavMeshAgent agent;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     agent = GameObject.Find("Enemy").GetComponent<NavMeshAgent>();
    //     navMesh = GetComponent<NavMeshSurface>();
    //     // agent. = navMesh.BuildNavMesh();

    // }

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

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
