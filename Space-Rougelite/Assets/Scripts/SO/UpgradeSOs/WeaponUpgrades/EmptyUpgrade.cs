using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmptyUpgrade", menuName = "SO/Upgrades/Empty", order = 1)]
public class EmptyUpgrade : Upgrade
{
    public override void DoUpgrade()
    {
        tier++;
    }

    public override void OnReset()
    {
        tier = 0;
    }
}
