using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    //holds array of possible items to spawn.
    public GameObject[] Common;
    public GameObject[] Uncommon;
    public GameObject[] Rare;
    public int weightCommon, weightUncommon, weightRare;
    //chosen array
    private GameObject[] Chosen;
    //the spawn point of the object
    private Vector3 spawnpoint;
    //decides which item
    private int rand;
    //decides what rarity
    private int rarity;
    protected override void Interact()
    {
        //randomly generates a number using the weights
        rarity = Random.Range(0, weightRare + weightUncommon + weightCommon + 1);

        //sets the chosen array up
        if (rarity <= weightRare)
        {
            Chosen = Rare;
        }
        else if (rarity <= weightUncommon + weightRare)
        {
            Chosen = Uncommon;
        }
        else
        {
            Chosen = Common;
        }

        //gets position of object
        rand = Random.Range(0, Chosen.Length);
        spawnpoint = gameObject.transform.position;
        //creates Object
        Instantiate(Chosen[rand], spawnpoint, Quaternion.identity);
        Destroy(gameObject);
    }
}
