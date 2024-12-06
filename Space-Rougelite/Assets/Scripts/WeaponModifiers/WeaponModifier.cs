using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponModifier
{
    virtual public void Fire(GameObject bullet, Vector3 pos, Quaternion rot, Vector2 dir) { }

    virtual public void SetUpgrade(IWeaponModifier prev) { }
}
