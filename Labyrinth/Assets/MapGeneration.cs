using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour, ICollectible
{
    public void collect()
    {

        gameObject.layer = 8;
        foreach (Transform child in transform)
        {
            child.gameObject.layer = 8;
        }

        BoxCollider bx = GetComponent<BoxCollider>();
        bx.enabled = false;
    }
}
