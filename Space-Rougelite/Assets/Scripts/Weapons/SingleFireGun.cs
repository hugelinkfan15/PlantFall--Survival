using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SingleFireGun : Weapon
{
    [SerializeField] protected GameObject bullet;
    public BaseSingleFire modifiedFire;
    //public Transform launchOffset;

    private Vector2 mousePosition;
    private Vector2 direction;

    protected new void Update()
    {
        float h = Input.mousePosition.x - Screen.width / 2;
        float v = Input.mousePosition.y - Screen.height / 2;
        float angle = -Mathf.Atan2(v, h) * Mathf.Rad2Deg;
        
        if (h < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(180,0, angle);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,-angle);
        }
    }

    /// <summary>
    /// Fires a projectile towards the position of the mouse. Paramaters currently serve no purpose
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="range"></param>
    /// <param name="speed"></param>
    public void Fire(float damage, float range, float speed)
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        modifiedFire.Fire(bullet, transform.position, transform.rotation, direction);
        //Instantiate(bullet, transform.position, transform.rotation).gameObject.GetComponent<Rigidbody2D>().velocity = direction * PlayerStats.bulletSpeed * PlayerStats.bulletSpeedMult;
    }
}
