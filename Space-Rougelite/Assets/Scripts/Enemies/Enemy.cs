using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float maxHealth;
    protected float health;

    public float speed;
    public float damage;

    public GameObject drop;
    protected Transform player;
   
    [SerializeField] protected int spawnWave;
    protected static float contactCD = 0.2f;

    protected float cooldown;
    // Start is called before the first frame update
    public void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cooldown = contactCD;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    // Update is called once per frame
    protected void Update()
    {
        cooldown += Time.deltaTime;
        if (health <= 0)
        {
            Die();
        }

        if (player.position.x - transform.position.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
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
        ObjectPooler.Instance.poolDictionary[spawnWave].Enqueue(gameObject);
        -- EnemySpawner.Instance.currentEnemies;
        health = maxHealth;
        StopAllCoroutines();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Inflicts damage when colliding with GameObject with a "Player" tag
    /// </summary>
    /// <param name="collision"></param>
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    protected void OnCollisionStay2D(Collision2D collision)
    {
        if ( contactCD < cooldown && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            cooldown = 0.0f;
        }
    }

    protected void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(RespawnOnScreen());
        }
    }

    protected void OnBecameVisible()
    {
        StopAllCoroutines();
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
