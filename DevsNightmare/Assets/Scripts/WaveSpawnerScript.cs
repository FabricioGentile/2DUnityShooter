using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerScript : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    private float waveCountDown;
    private float searchCountDown = 1f;
    public LevelLoaderScript lvl;

    public Transform[] spawPoints;

    private SpawnState state = SpawnState.COUTING;
    // Start is called before the first frame update
    void Start()
    {
        waveCountDown = timeBetweenWaves;
       
        if (spawPoints.Length == 0)
        {
            Debug.Log("No spawn points");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
           //check if enemies are still alive
           if (!EnemyIsAlive())
            {
                //Begin a new round 
                WaveCompleted();
            }
           else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
           if (state != SpawnState.SPAWNING)
            {
                //start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 >= waves.Length )
        {

            waveCountDown = 100000000f;
            Debug.Log("Completed all waves");
            Debug.Log("score value is : " + ScoreScript.scoreValue);
            if (ScoreScript.scoreValue == 50)
            {
                //next level
                lvl.LoadNextLevel();
            }
            else
            {
                //gameover
                
            }
            


        }
        else
        {
            //change this
            nextWave++;
        }
     
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy1") == null && GameObject.FindGameObjectWithTag("Enemy2") == null)
            {
                return false;
            }
        }
        
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        //Spawn
        for (int i = 0;  i <  _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Transform _sp = spawPoints[Random.Range(0, spawPoints.Length)];

        Instantiate(_enemy, _sp.position, _sp.rotation);
        //Spawn enemy
        
    }
}
