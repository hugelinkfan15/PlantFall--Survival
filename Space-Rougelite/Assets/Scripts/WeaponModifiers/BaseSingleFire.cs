using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingleFire: MonoBehaviour, IWeaponModifier
{
    virtual public void SetUpgrade(BaseSingleFire prev)
    {

    }
    virtual public void Fire(GameObject bullet, Vector3 pos, Quaternion rot, Vector2 dir) => Instantiate(bullet, pos, rot).gameObject.GetComponent<Rigidbody2D>().velocity = dir * PlayerStats.bulletSpeed * PlayerStats.bulletSpeedMult;
}
