using JetBrains.Annotations;
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
    public int pierce;
    private int enemiesHit;
    //public Transform direction;

    protected Rigidbody2D rb;
    private float distanceTravelled;
    private Vector3 prev;

    public List<BulletModifier > modifiers;

    protected void Start()
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
    public void SetBulletAtributes(float d, float r, float s, Vector2 dir)
    {
        speed = s;
        damage = d;
        range = r;
        rb.velocity = dir * s;
    }

    /// <summary>
    /// Keeps track of how far bullet has travelled, deletes it if it's reached it's maxium range
    /// </summary>
    protected void Update()
    {
        damage = PlayerStats.damage * PlayerStats.damageMult;
        range = PlayerStats.range * PlayerStats.rangeMult;
        pierce = PlayerStats.pierce;
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
            if (enemiesHit < pierce)
            {
                enemiesHit++;
                collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                foreach (BulletModifier modi in modifiers)
                {
                    StartCoroutine(modi.GiveEffect(collision.gameObject.GetComponent<Enemy>()));
                }
                Destroy(gameObject);
            }
        }
    }
}
