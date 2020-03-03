﻿using System.Collections;
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

        float yValue = Mathf.Clamp(rb.position.y, -12.0f, 12.0f);
        float xValue = Mathf.Clamp(rb.position.x, -11.0f, 28.0f);
        rb.position = new Vector2(xValue, yValue);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
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
                    playerHealth.Damage(2);
                }
            }
        }
    }


}
