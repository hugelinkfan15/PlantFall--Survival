using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : Enemy
{
    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (!PauseMenu.isPaused)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
