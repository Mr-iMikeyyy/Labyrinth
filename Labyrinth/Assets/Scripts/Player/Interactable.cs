using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public string promptMessage;

    //this is called from player
    public void BaseInteract() {
        Interact();
    }

    //overide this.
    protected virtual void Interact() {

    }
}
