using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Speed of the spaceship
    public Vector2 speed = new Vector2(10, 10);

    //Movement of the spaceship

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    { 
        Move();

    }

    private void Move()
    {
        //Positions
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //Move the game object
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(inputX * speed.x, inputY * speed.y); ;
    }

}
