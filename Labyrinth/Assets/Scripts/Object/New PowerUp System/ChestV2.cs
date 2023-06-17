using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestV2 : Interactable
{
    //holds array of possible items to spawn.
    private List<GameObject> Common;
    private List<GameObject> Uncommon;
    private List<GameObject> Rare;

    //the data list used
    public ItemList Ilist;

    public int weightCommon, weightUncommon, weightRare;
    //chosen array
    private List<GameObject> Chosen;
    //the spawn point of the object
    private Vector3 spawnpoint;
    //decides which item
    private int rand;
    //decides what rarity
    private int rarity;
    private Animator chestAnimator;
    private void OnEnable()
    {
        Common = Ilist.getList('C');
        Uncommon = Ilist.getList('U');
        Rare = Ilist.getList('R');
    }

    private void Start()
    {
        chestAnimator = GetComponent<Animator>();
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
        rand = Random.Range(0, Chosen.Count);
        spawnpoint = gameObject.transform.position;
        //creates Object
    }
    protected override void Interact()
    {
        chestAnimator.Play("Chest Opening");
        Instantiate(Chosen[rand], spawnpoint, Quaternion.identity);
        //Destroy(gameObject);
    }
 
}