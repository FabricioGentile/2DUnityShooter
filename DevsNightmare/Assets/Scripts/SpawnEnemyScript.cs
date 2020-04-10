using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour
{
    public Transform enemyPreFab;

    public float spawnRate = 2f;

    private bool isPositionPlayer = false;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Spawn", spawnRate, spawnRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        isPositionPlayer = !isPositionPlayer;

        Vector2 spawnPosition;

        if (isPositionPlayer && playerTransform != null)
        {
            spawnPosition = new Vector2(transform.position.x, playerTransform.position.y);
        }
        else
        {
            spawnPosition = new Vector2(transform.position.x, Random.Range(8,0));
        }

        var enemyTransform = Instantiate(enemyPreFab) as Transform;

        enemyTransform.position = spawnPosition;
    }
}
