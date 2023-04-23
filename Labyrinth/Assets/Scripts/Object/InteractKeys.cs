using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractKeys : Interactable
{
    public string keyType;

    private void Start()
    {
        if (keyType == null || keyType == "")
        {
            keyType = "White";
        }
    }

    override protected void Interact()
    {
        //Destroys the object
        PlayerInventory.addKey(keyType);
        Destroy(gameObject);
    }
}
