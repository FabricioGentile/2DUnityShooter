using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    //Speed of the enemy
    public Vector2 speed = new Vector2(5, 5);

    private Rigidbody2D rb;
    public Vector2 direction = new Vector2(-1, 0);

    // Start is called before the first frame update
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

        //Move the game object
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direction.x * speed.x, direction.y * speed.y); ;
    }
}
