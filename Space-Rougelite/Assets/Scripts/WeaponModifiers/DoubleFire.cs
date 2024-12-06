using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleFire : BaseSingleFire
{
    [SerializeField] private float secondFireDelay = 0.5f;
    public BaseSingleFire previous;

    public override void SetUpgrade(BaseSingleFire prev)
    {
        this.previous = prev;
    }

    public override void Fire(GameObject bullet, Vector3 pos, Quaternion rot, Vector2 dir)
    {
        previous.Fire(bullet, pos, rot, dir);
        StartCoroutine(SecondFire(bullet, pos, rot, dir));
    }

    IEnumerator SecondFire(GameObject b, Vector3 p, Quaternion r, Vector2 d)
    {
        yield return new WaitForSeconds(secondFireDelay);

        previous.Fire(b, p, r, d);

    }
}
