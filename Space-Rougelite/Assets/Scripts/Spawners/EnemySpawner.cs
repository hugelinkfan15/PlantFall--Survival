using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public int wave;
    public int maxEnemies;
    public Transform playerLocation;

    [SerializeField] private int spawnRadius;
    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        //List<Enemy> currentWave = waveList[wave];
        Vector3 spawnspot = new Vector3((playerLocation.position.x + Random.value * spawnRadius), (playerLocation.position.y + Random.value * spawnRadius));
        Instantiate(Enemy/*currentWave[Random.Range(0, currentWave.Count)]*/, spawnspot,Quaternion.identity);
    }

    
}
