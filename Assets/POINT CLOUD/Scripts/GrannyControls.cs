using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GrannyControls : MonoBehaviour
{
    // Animator Controller component variable
    private Animator anim;

    [SerializeField]
    private float speed = 2f; //speed of granny's movement
    [SerializeField]
    private float rotationSpeed = 10f; //speed of granny's movement

    // variables to set the movement & rotation
    private Vector3 movement;
    private Quaternion rotation;
    private bool walking;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Animator Controller of the attached Game Object
        anim = GetComponent<Animator>();

        //initialize the movement
        movement.Set(0, 0, 0);
    }

    void FixedUpdate()
    {
        // Get the horizontal and vertical axis.
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        // move the game object accordingly
        Move(h, v);

        //rotate it according to the walking direction
        Rotate(h, v);

        //animate it if walking
        Animate(h, v);

        // if Key ‘Space’ is pressed the ‘Jump’ trigger is activated 
        if (Input.GetKeyDown("space"))
        {
            // Tell the animator the player is jumping
            anim.SetTrigger("Jump");
        }

    }

    // Function to move the game object
    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input
        movement.Set(h, 0, v);

        // Normalize the movement vector and make it proportional to the speed per second
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement
        GetComponent<Rigidbody>().MovePosition(transform.position + movement);

    }

    // Function to rotate the game object when walking
    void Rotate(float h, float v)
    {
        // boolean that is true if either one of the input axes is non-zero
        walking = (h != 0f || v != 0f);

        // Rotate the game object according to the direction of movement
        if(walking)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * rotationSpeed);
    
    }

    // Function to animate the game object when walking
    void Animate(float h, float v)
    {
        // boolean that is true if either one of the input axes is non-zero
        walking = (h != 0f || v != 0f);

        // Tell the animator whether or not the player is walking
        anim.SetBool("Walking", walking);
    
    }
}
