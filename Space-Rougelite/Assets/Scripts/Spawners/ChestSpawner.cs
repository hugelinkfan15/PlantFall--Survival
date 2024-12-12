using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : Singleton<ChestSpawner>
{
    public GameObject chest;
    public Queue<GameObject> chestQueue;
    public List<GameObject> pointers;

    public Timer timer;

    public ChestManager chestManager;

    public int chestsToSpawn;

    public float waitTime;

    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update-

    private void Start()
    {
        chestQueue = new Queue<GameObject>();
        for(int i = 0; i< chestsToSpawn; i++)
        {
            GameObject obj = Instantiate(chest);
            pointers[i].GetComponent<TargetIndicator>().Target = obj.transform;
            obj.GetComponent<GetLoot>().pointer = pointers[i];
            obj.SetActive(false);
            chestQueue.Enqueue(obj);
        }
        StartCoroutine(SpawnChests());
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void Spawn()
    {
        GameObject temp = chestQueue.Dequeue();
        temp.SetActive(true);
        temp.transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
    }
    IEnumerator SpawnChests()
    {
        int spawned = 0;
        while (spawned < chestsToSpawn)
        {
            yield return new WaitForSeconds(waitTime);
            Spawn();

        }
    }
}
