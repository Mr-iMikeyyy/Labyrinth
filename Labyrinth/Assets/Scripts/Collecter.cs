using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lets the player body touch another object to activate it.
public class Collecter : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //gets info from collided object
        ICollectible collectible = other.GetComponent<ICollectible>();
        //checks if collected object is already collected
        if(collectible != null)
        {
            collectible.collect();
        }
    }

}
