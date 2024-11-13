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
    protected void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - new Vector2(transform.position.x,transform.position.y)).normalized;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            lastFired = Instantiate(bullet, transform.position, transform.rotation);
            lastFired.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
   
        }
    }
}
