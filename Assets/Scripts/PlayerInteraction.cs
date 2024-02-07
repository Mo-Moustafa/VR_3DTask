using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Camera cam;
    [SerializeField] 
    private float interactDistance = 5f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI; 
    private InputManager inputManager;
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, interactDistance, mask)){
            if(hitInfo.collider.GetComponent<Interactable>()!=null){
                Interactable interactable= hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage + " (E)");
                if(inputManager.onFoot.Interact.triggered){
                    interactable.BaseInteract();
                }
            }
        }
        
    }
}
