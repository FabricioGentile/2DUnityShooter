using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// code adapted from brackeys https://www.youtube.com/watch?v=Vrld13ypX_I with some changes
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
    public Font font;
    private string wcd;
    private GUIStyle guiStyle = new GUIStyle();

    public Transform[] spawPoints;

    private SpawnState state = SpawnState.COUTING;
    // Start is called before the first frame update
    void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (state == SpawnState.WAITING)
        {
            //Begin a new round 
            WaveCompleted();
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
        state = SpawnState.COUTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 >= waves.Length )
        {
            //
            waveCountDown = 100000000f;
            switch (ScoreScript.scoreValue)
            {
                case 200:
                case 500:
                    lvl.LoadNextLevel();
                    break;
                default:
                    transform.gameObject.AddComponent<GameOverScript>();
                    break;
            }
        }
        else
        {
            nextWave++;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
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
        Transform _sp = spawPoints[Random.Range(0, spawPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);   
    }

    private void OnGUI()
    {
        //check which leve is on and change the color to white or black
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            guiStyle.normal.textColor = Color.black;
        }
        else
        {
            guiStyle.normal.textColor = Color.white;
        }
        
        //displays the countdown in the screen
        wcd = "Next wave: " + waveCountDown.ToString("n2"); 
        GUI.skin.font = font;
        GUI.Label(new Rect(Screen.width / 2, 5, 100, 200), wcd, guiStyle);
    }
}
