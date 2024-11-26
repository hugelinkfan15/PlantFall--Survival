using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] protected GameObject bullet;
    //public Transform launchOffset;

    private Vector2 mousePosition;
    private Vector2 direction;
    /// <summary>
    /// Tracks position of mouse to both turn and shoot in it's direction
    /// </summary>

    public void Fire(float damage, float range, float speed)
    {
        float h = Input.mousePosition.x - Screen.width / 2;
        float v = Input.mousePosition.y - Screen.height / 2;
        float angle = -Mathf.Atan2(v, h) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -angle);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        Instantiate(bullet, transform.position, transform.rotation).gameObject.GetComponent<Rigidbody2D>().velocity = direction * PlayerStats.bulletSpeed;
       //lastFired.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
