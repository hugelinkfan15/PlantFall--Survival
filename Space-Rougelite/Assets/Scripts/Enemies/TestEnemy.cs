using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        health = 50f;
        speed = 2f;
        damage = 10f;
    }

    // Update is called once per frame
    new void Update()
    {
       /* if(player.position.x - transform.position.x <0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent <SpriteRenderer>().flipX = false;
        }*/
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed *Time.deltaTime);
    }
}
