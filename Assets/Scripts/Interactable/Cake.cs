using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : Interactable
{
    [SerializeField]
    

    protected override void Interact(){
        gameObject.SetActive(false);
    }
}
