using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;
    private Rigidbody playerBody;
    
    
    private float width;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
       //cam = GameObject.FindGameObjectWithTag("MainCamera").transform. 

        width = boxCollider.size.x;
                
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerBody.velocity.x;
        rigidBody.velocity = new Vector2(-speed, 0);
        if (playerBody.position.x > rigidBody.position.x + width * 4)
        {
            Reposition();
        }
        
    }

    void Reposition()
    {
        Vector2 vector = new Vector2(width * 10, 0);
        transform.position = (Vector2)transform.position + vector; 
    }
}
