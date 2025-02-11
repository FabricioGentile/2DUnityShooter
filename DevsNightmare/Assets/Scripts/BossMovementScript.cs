﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementScript : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;
    private string objTag;
    public LevelLoaderScript lvl;

    [SerializeField]
    private float speed = 0f;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    // Start is called before the first frame update
    void Start()
    {
        posA= childTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
        objTag = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        //if the boss still alive, keeps moving, otherwise load next level
        if (GameObject.FindGameObjectWithTag("Boss1") != null || GameObject.FindGameObjectWithTag("Boss2") != null)
        {
            Move();
        }
        else
        {
            lvl.LoadNextLevel();
        }
        
    }

    private void Move()
    {
        //move towards the gameObject
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, nextPos) <= 0.1)
        {
            changeMovement();
        }
    }

    private void changeMovement()
    {
        //checks if next position is A or B and assign to the different position
        nextPos = nextPos != posA ? posA : posB;
    }
}
