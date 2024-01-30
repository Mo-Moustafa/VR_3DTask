using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool lerpCrouch, crouching, sprinting = false;
    private float speed;
    public float setSpeed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public float crouchTimer = 1f;




    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = setSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (lerpCrouch){
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);

            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1){
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }

    }

    public void ProcessMove(Vector2 input){
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        
        playerVelocity.y += gravity * Time.deltaTime; 
        if(isGrounded && playerVelocity.y < 0){
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);

    }

    public void Jump(){
        playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }

    public void Sprint(){
        sprinting = !sprinting;
        if(sprinting)
            speed = setSpeed + 5f;

        else
            speed = setSpeed;

    }

    public void Crouch(){
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

}
