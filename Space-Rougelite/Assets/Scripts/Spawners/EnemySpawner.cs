using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public int wave;
    public float spawnCD;

    public int currentEnemies;
    public int maxEnemies;


    public Transform playerLocation;

    #region Singleton
    public static EnemySpawner Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] private int spawnRadius;
    private float sincelastSpawn;
    private Vector3 spawnSpot;

    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        sincelastSpawn = 0.0f;
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(WaveIncrease());
    }

    // Update is called once per frame
    void Update()
    {
        sincelastSpawn += Time.deltaTime;
        //List<Enemy> currentWave = waveList[wave];
        spawnSpot = new Vector3((playerLocation.position.x + Mathf.Cos(Random.Range(0f,Mathf.PI*2)) * spawnRadius), (playerLocation.position.y + Mathf.Sin(Random.Range(0f,Mathf.PI*2)) * spawnRadius));
        if(currentEnemies < maxEnemies && sincelastSpawn>spawnCD)
        {
            sincelastSpawn = 0.0f;
            ++currentEnemies;
            ObjectPooler.Instance.SpawnFromPool(wave, spawnSpot,Quaternion.identity).gameObject.GetComponent<Enemy>().SetWave(wave);
        }
    }

    /// <summary>
    /// Called by enemy after they have been off screen for a long period of time
    /// </summary>
    /// <param name="enemy"></param>
    public void Respawn(GameObject enemy)
    {
        enemy.gameObject.transform.position = spawnSpot;
    }

    /// <summary>
    /// Increase waves every minute, along with increasing maxEnemies every two and reducing spawn cooldoen every 3
    /// </summary>
    /// <returns></returns>
    IEnumerator WaveIncrease()
    {
        while (wave < 10)
        {
            yield return new WaitForSeconds(60f);

            wave++;

            if (wave % 2 == 0)
            {
                maxEnemies += 15;
            }

            if (wave % 3 == 0 && spawnCD > 0.0f)
            {
                spawnCD -= 0.2f;
            }
        }
    }
    
}
