using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.AI;
public class UnlockedDoor : Interactable
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private Collider Parentcollider;
    [SerializeField] private GameObject parent;
    private GameObject nmesh;
    private NavMeshSurface navmesh;
    [SerializeField] private NavMeshObstacle obstacle;
    public AudioSource doorOpenSound;
    private bool doorOpen;
    private float timesincelastpress = 0;
    private bool inProcess;
    void Start()
    {
        doorOpen = false;
        inProcess = false;
        nmesh = GameObject.Find("NavMesh");
        navmesh = nmesh.GetComponent<NavMeshSurface>();
    }

    private void Update()
    {
        timesincelastpress += Time.deltaTime;
    }
    override protected void Interact()
    {
        if (inProcess == false)
        {
            inProcess = true;
            if (doorOpen == false && timesincelastpress > 1)
            {
                Debug.Log("open");
                Parentcollider.enabled = false;
                doorAnimator.Play("door opening");
                doorOpenSound.Play();
                timesincelastpress = 0;
                obstacle.enabled = false;
                changeDoor();
            }
            else if (doorOpen == true && timesincelastpress > 1)
            {
                Debug.Log("close");
                Parentcollider.enabled = true;
                doorAnimator.Play("door closing");
                doorOpenSound.Play();
                timesincelastpress = 0;
                obstacle.enabled = true;
                changeDoor();
            }
            navmesh.BuildNavMesh();
            inProcess = false;
        }
    }

    private void changeDoor()
    {
        if (doorOpen == true)
        {
            doorOpen = false;
        }
        else
        {
            doorOpen = true;
        }
    }
}
