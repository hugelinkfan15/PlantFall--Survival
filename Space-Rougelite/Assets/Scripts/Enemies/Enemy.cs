using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float maxHealth;
    protected float health;

    public float speed;
    public float damage;

    public GameObject drop;
    protected Transform player;

    protected int spawnWave;
    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void SetWave(int w)
    {
        spawnWave = w;
    }

    /// <summary>
    /// Drops the Enemy's respective Item
    /// </summary>
    public void Drop()
    {
        Instantiate(drop,gameObject.transform.position,Quaternion.identity);
    }

    public void Die()
    {
        Drop();
        ObjectPooler.Instance.poolDictionary[spawnWave].Enqueue(gameObject);
        -- EnemySpawner.Instance.currentEnemies;
        gameObject.SetActive(false);
        health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
