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
        //Destroys the object
        PlayerInventory.addKey("White");
        PlayerInventory.addPowerup(1, "Dog");
        PlayerInventory.addPowerup(2, "Gun");
        PlayerInventory.addPowerup(3, "Shield");
        Destroy(gameObject);
        //This lets other functions react to this variable activating.
        OnCollected?.Invoke();
    }
}
