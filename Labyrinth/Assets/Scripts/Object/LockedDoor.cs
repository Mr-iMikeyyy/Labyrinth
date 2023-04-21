using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Interactable
{
    [SerializeField] public string keyType;
    [SerializeField] private Animator doorAnimator;
    private Collider thiscoll;
    public AudioSource doorOpenSound;
    public AudioSource doorLockedSound;

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
            doorOpenSound.Play();
            thiscoll.enabled = false;
        }
    }
}
