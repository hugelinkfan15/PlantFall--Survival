using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileUpgrade", menuName = "SO/Upgrades/ProjectileNum", order = 0)]
public class ProjectileUpgrade : Upgrade
{
    public override void DoUpgrade()
    {
        PlayerStats.projectileNumber++;
        tier++;
    }

    public override void OnReset()
    {
        tier = 0;
    }
}
