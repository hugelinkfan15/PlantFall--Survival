using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Bullet
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Overrides Bullet class's function, sets damage, speed, and direction of the projectile
    /// *****WIP********
    /// </summary>
    /// <param name="d"></param>
    /// <param name="s"></param>
    /// <param name="dir"></param>
    public void SetBulletAtributes(float d,float s, Vector2 dir)
    {
        damage = d;
        speed = s;
        rb.velocity = dir * s;
    }

    /// <summary>
    /// Destroys this projectile once off screen
    /// </summary>
    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
