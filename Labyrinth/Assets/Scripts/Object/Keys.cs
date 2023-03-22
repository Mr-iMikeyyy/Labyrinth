using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Keys :MonoBehaviour, ICollectible {

    [SerializeField] string keytype;

    private void Start()
    {
        if (keytype == null)
        {
            keytype = "White";
        }
    }

    public void collect()
    {
        //Destroys the object
        PlayerInventory.addKey(keytype);
        Destroy(gameObject);
    }
}
