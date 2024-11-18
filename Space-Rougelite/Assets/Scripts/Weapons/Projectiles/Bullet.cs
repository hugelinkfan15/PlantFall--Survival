using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps various stats of about the Bullet Object it is attached to.
/// Also Deletes itself after touch a bullet or it reaches it's maxium range
/// </summary>
public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public float range;
    //public Transform direction;

    private Rigidbody2D rb;
    private float distanceTravelled;
    private Vector3 prev;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        prev = transform.position;
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

    /// <summary>
    /// Keeps track of how far bullet has travelled, deletes it if it's reached it's maxium range
    /// </summary>
    private void Update()
    {
        distanceTravelled += Vector3.Distance(transform.position, prev);
        if (distanceTravelled > range)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Checks to see if it's collided with on enemy object
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
