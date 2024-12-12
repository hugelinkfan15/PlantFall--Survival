using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletModifier : Upgrade
{
    public override void DoUpgrade()
    {
        PlayerStats.modifiers.Add(this);
    }

    public override void OnReset()
    {
        tier = 0;
    }

    public abstract IEnumerator GiveEffect(Enemy e);
}
