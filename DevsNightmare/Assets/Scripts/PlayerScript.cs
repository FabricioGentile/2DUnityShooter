using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
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

        //if the player clicks the mouse with the left click, it shoots
        if (Input.GetButtonDown("Fire1"))
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack();
            }
        }
    }
  
    private void Move()
    {
        //Positions
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //Move the game object
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(inputX * speed.x, inputY * speed.y);

        //keeps the player inside the screen
        float yValue = Mathf.Clamp(rb.position.y, -70.0f, 100.0f);
        float xValue = Mathf.Clamp(rb.position.x, -25.0f, 390.0f);
        rb.position = new Vector2(xValue, yValue);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // checks if the player collide with the enemy and gives the appropriate damage
        if(collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Enemy2")
        {
            var damagePlayer = false;
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
            
            if(enemy != null)
            {
                HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
                if(enemyHealth != null)
                {
                    enemyHealth.Damage(enemyHealth.hp);
                }

                damagePlayer = true;
            }

            if (damagePlayer)
            {
                HealthScript playerHealth = GetComponent<HealthScript>();
                if(playerHealth != null)
                {
                    playerHealth.Damage(1);
                }
            }
        }
    }

    //if the player is destroyed, loads the game over scrip 
    private void OnDestroy()
    {
        transform.parent.gameObject.AddComponent<GameOverScript>();
    }
}
