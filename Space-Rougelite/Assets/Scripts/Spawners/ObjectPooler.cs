using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public int wave;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<int, Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<int, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            
            for(int i = 0; i<pool.size;i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            if (poolDictionary.ContainsKey(pool.wave))
            {
                foreach(GameObject o in objectPool)
                {
                    poolDictionary[pool.wave].Enqueue(o);
                }
            }
            else
            {
                poolDictionary.Add(pool.wave, objectPool);
            }
        }

    }

    public GameObject SpawnFromPool (int wave, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(wave))
        {
            Debug.LogWarning("Pool with tag " + wave + " doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[wave].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;    
        objectToSpawn.transform.rotation = rotation;

        //poolDictionary[wave].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
