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

    // Start is called before the first frame update
    void Start()
    {
        sincelastSpawn = 0.0f;
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform; 
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

    
}
