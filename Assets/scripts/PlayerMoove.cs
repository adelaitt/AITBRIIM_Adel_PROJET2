using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoove : MonoBehaviour
{
    private CharacterController controller;

    private float speed = 40.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    public Rigidbody rb;
    private Vector3 direction;


    public float jumpForce;
    private float animationDuration = 2.7f;
    private float startTime;

    private bool isDead = false;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;
        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }



        //X left and right 
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

       

        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
        
    }

    public void SetSpeed(float modifier)
    {
        speed = 40.0f + modifier;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
            Death();
    }
    private void Death()
    {
        Debug.Log("Dead");
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }
    
}
