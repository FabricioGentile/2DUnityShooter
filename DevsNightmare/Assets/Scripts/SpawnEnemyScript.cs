using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour
{
    public Transform enemyPreFab;

    public float spawnRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        var enemyTransform = Instantiate(enemyPreFab) as Transform;

        enemyTransform.position = transform.position;
    }
}
