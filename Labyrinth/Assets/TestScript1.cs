using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
using System.Linq;

public class TestScript1 : MonoBehaviour
{
    private List<GameObject> prefabs;
    private List<NavMeshSurface> surface;
    // Use this for initialization
    void Start()
    {
        prefabs = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g => g.tag == "Floor").ToList();

        surface = Resources.FindObjectsOfTypeAll(typeof(NavMeshSurface)).Cast<NavMeshSurface>().ToList();

        for (int i = 0; i < surface.Count; i++)
        {
            surface[i].BuildNavMesh();
        }
    }
    private void Update()
    {

        for (int i = 0; i < surface.Count; i++)
        {
            Debug.Log(surface.Count);
            surface[i].BuildNavMesh();
        }
    }
}
