using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeaponModifier
{
    public void Fire(GameObject bullet, Vector3 pos, Quaternion rot, Vector2 dir) { }
}
