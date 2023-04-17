using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable
{
    [SerializeField] public string keyType;
    [SerializeField] private Animator doorAnimator;

    void Start()
    {
        if (keyType == null)
        {
            keyType = "White";
        }
    }

    override protected void Interact()
    {
        if (PlayerInventory.checkKeys(keyType))
        {
            PlayerInventory.removeKey(keyType);
            // Destroy(gameObject);
            // doorAnimator.SetTrigger("DoorATrigger");
            doorAnimator.Play("DoorATrigger");
        }
    }
}
