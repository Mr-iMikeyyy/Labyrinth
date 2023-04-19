using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable
{
    [SerializeField] public string keyType;
    [SerializeField] private Animator doorAnimator;
    private Collider thiscoll;

    void Start()
    {
        if (keyType == null)
        {
            keyType = "White";
        }
        thiscoll = GetComponent<Collider>();
    }

    override protected void Interact()
    {
        if (PlayerInventory.checkKeys(keyType))
        {
            PlayerInventory.removeKey(keyType);
            // Destroy(gameObject);
            doorAnimator.Play("door opening");
            thiscoll.enabled = false;
        }
    }
}
