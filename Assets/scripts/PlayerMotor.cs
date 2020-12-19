
using System.Collections;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    CharacterController characterController;


    public float moveSpeed;
    public float gravity;
    public float jumpspeed;


    private void start()
    {
        characterController = GetComponent<CharacterController>();

    }


    // Update is called once per frame
    void Update()
    {
        if ( Input.GetButton("Jump"))
            moveVector.y = jumpspeed;
       
            moveVector.y -= gravity * Time.deltaTime;
        
    }
}
