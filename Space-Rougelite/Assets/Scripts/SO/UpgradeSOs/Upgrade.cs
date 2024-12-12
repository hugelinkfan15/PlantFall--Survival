using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    public string upgradeName;
    public string description;
    public int tier;
    public int maxTier;

    public abstract void DoUpgrade();
    public abstract void OnReset();
}
