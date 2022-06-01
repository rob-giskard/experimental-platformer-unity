using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    Rigidbody rigidbodyComponent;
    Renderer rendererComponent;
    Vector3 checkpoint1;
    Vector3 checkpoint2;
    Vector3 currentPos;
    bool jumpKeyWasPressed;
    float horizontalInput;
    int coinsCollected;
    int speed;
    int jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        rendererComponent = GetComponent<Renderer>();
        checkpoint1 = GameObject.FindGameObjectWithTag("Checkpoint1").transform.position;
        checkpoint2 = GameObject.FindGameObjectWithTag("Checkpoint2").transform.position;
        coinsCollected = 0;
        speed = 2;
        jumpHeight = 7;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if space key was pressed
        //Only check for user input in Update and then apply physics in FixedUpdate
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE PRESS");
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        
        //Track player's position 
        currentPos = transform.position;
        
    }
    //FixedUpdate is called once every physics update
    //Its better to apply physics here
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput * speed, rigidbodyComponent.velocity.y, 0);

        // Respawn player at checkpoint1 
        if (currentPos.y < -3)
        {
            transform.position = checkpoint1;
        }

        // Respawn player at Checkpoint2
        if (currentPos.y < -3 && currentPos.x >= checkpoint2.x)
        {
            transform.position = checkpoint2;
        }

        // Gain/lose power-ups after collecting specific amounts of coins
        if (coinsCollected > 0 && coinsCollected % 3 == 0)
        {
            rendererComponent.material.color = Color.red;
            speed = 4;
            jumpHeight = 8;
        }
        else
        {
            rendererComponent.material.color = Color.white;
            speed = 2;
            jumpHeight = 7;
        }

        //Don't let player jump when not on ground
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        //Checks if player should jump
        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }  

    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected.");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision ended.");
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            coinsCollected++;
        }
        else if (other.gameObject.layer == 8)
        {
            Destroy(other.gameObject);
            SimpleSpinningCoinCounter.spinningCoinsAmount++;
            Debug.Log("SPINNING COIN COLLECTED");

        }
    }
}