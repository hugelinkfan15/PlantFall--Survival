using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PierceUpgrade", menuName = "SO/Upgrades/PierceNum", order = 2)]

public class PierceUpgrade : Upgrade
{
    public override void DoUpgrade()
    {
        PlayerStats.pierce++;
        tier++;
    }
    public override void OnReset()
    {
        tier = 0;
    }
}
