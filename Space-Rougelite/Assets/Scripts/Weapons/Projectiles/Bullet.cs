using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public float range;
    //public Transform direction;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// THIS SHOULD BE CALLED WHEN INSTATIATING A BULLET.
    /// </summary>
    /// <param name="s">Speed of the Bullet</param>
    /// <param name="d">Damage of the Bullet></param>
    /// <param name="r">Range Bullet with travel before Destroying itself</param>
    public void SetBulletAtributes(float s, float d, float r, Vector2 dir)
    {
        speed = s;
        damage = d;
        range = r;
        rb.velocity = dir * s;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
