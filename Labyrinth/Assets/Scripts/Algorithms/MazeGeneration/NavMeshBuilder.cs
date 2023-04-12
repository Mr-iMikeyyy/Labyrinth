using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBuilder : MonoBehaviour
{
    private NavMeshSurface navMesh;
    // private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        // agent = GameObject.Find("Enemy").GetComponent<NavMeshAgent>();
        navMesh = GetComponent<NavMeshSurface>();
        navMesh.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
