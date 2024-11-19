using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] protected GameObject bullet;
    private GameObject lastFired;
    //public Transform launchOffset;

    public int bulletSpeed= 10;

    private Vector2 mousePosition;
    private Vector2 direction;
    /// <summary>
    /// Tracks position of mouse to both turn and shoot in it's direction
    /// </summary>
    protected new void Update()
    {
        float h = Input.mousePosition.x - Screen.width / 2;
        float v = Input.mousePosition.y - Screen.height / 2;
        float angle = -Mathf.Atan2(v, h) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0, -angle);
        base.Update();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - new Vector2(transform.position.x,transform.position.y)).normalized;
        if(isChild && Input.GetKeyDown(KeyCode.Mouse0))
        {
            lastFired = Instantiate(bullet, transform.position, transform.rotation);
            lastFired.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
   
        }
    }
}
