using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Test Object without using the abstract class
public class TEST_ITEM : MonoBehaviour, ICollectible
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
