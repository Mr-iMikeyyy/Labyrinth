using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using Unity.AI;
public class MazeNavMeshBuilderMP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        // GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    public void CreateNavMesh() {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
