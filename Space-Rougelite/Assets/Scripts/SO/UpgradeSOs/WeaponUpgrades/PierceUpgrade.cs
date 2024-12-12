using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
