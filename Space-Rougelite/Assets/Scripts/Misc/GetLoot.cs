using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLoot : MonoBehaviour
{
    public ChestManager manager;

    public GameObject pointer;

    private void OnEnable()
    {
        manager = GameObject.FindFirstObjectByType<ChestManager>();
        if (pointer != null)
        {
            pointer.SetActive(true);
        }
    }

    private void OnDisable()
    {
        pointer.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            manager.SetLoot();
            ChestSpawner.instance.chestQueue.Enqueue(gameObject);
            pointer.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
