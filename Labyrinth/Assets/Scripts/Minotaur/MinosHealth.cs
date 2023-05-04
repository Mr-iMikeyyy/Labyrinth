using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinosHealth : MonoBehaviour
{
    public int health;
    // private int maxHealth = 100;


    void start() { }

    public void takeDamage (int amt)
    {
        health -= amt;
        if (health <= 0)
        {
            Destroy(gameObject);
            //other options could be temporary effects that slow down the monster bc idk if we want
            //to be able to kill it
        }
    }

}
