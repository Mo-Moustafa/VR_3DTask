using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    public bool useEvents;

    public void BaseInteract(){
        if(useEvents){
            GetComponent<InteractionEvent>().interactionEvent.Invoke();
        }
        Interact();
    }

    protected virtual void Interact(){}
}   
