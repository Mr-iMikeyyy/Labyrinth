using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Abstract class. Override if needed.
public abstract class Collectible : MonoBehaviour, ICollectible
{
    public static event Action OnCollected;
    // Start is called before the first frame update
    public void collect()
    {
        Debug.Log("item collected");
        //Destroys the object
        Destroy(gameObject);
        //This lets other functions react to this variable activating.
        OnCollected?.Invoke();
    }
}
