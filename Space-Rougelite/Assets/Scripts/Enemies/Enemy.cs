using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    public float damage;
    public GameObject drop;
    protected Transform player;
    // Start is called before the first frame update
    protected void Start()
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

    /// <summary>
    /// Drops the Enemy's respective Item
    /// </summary>
    public void Drop()
    {
        Instantiate(drop,gameObject.transform);
    }
    public void Die()
    {
        //Drop();
        Destroy(gameObject);
    }
}
