using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletModifier : Upgrade
{
    public override void DoUpgrade()
    {
        if (tier == 0)
        {
            PlayerStats.modifiers.Add(this);
        }
        else
        {
            tier++;
        }
    }

    public override void OnReset()
    {
        tier = 0;
    }

    public abstract IEnumerator GiveEffect(Enemy e);
}
