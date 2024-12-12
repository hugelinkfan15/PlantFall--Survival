using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLoot : MonoBehaviour
{
    public ChestManager manager;

    private void OnEnable()
    {
        manager = GameObject.FindFirstObjectByType<ChestManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            manager.SetLoot();
            gameObject.SetActive(false);
        }
    }
}
