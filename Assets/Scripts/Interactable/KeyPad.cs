using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool isOpen = false;

    protected override void Interact(){
        isOpen = !isOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", isOpen);
    }
}
