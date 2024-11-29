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

    private bool dead;

    protected int spawnWave;
    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        dead = true;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (gameObject.activeSelf) { dead = false; }
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

    /// <summary>
    /// Calls Drop function, then disables enemy, pushes them back into ObjectPool, and resets health
    /// </summary>
    public void Die()
    {
        Drop();
        dead = true;
        ObjectPooler.Instance.poolDictionary[spawnWave].Enqueue(gameObject);
        -- EnemySpawner.Instance.currentEnemies;
        health = maxHealth;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Inflicts damage when colliding with GameObject with a "Player" tag
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private void OnBecameInvisible()
    {
        if (!dead)
        {
            StartCoroutine(RespawnOnScreen());
        }
    }

    private void OnBecameVisible()
    {
        StopCoroutine(RespawnOnScreen());
    }


    /// <summary>
    /// Respawns enemy closer to player if they've been offscreen for too long
    /// </summary>
    /// <returns></returns>
    IEnumerator RespawnOnScreen()
    {
        yield return new WaitForSeconds(5.0f);

        EnemySpawner.Instance.Respawn(gameObject);
    }


}
