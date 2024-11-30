using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelUpOption", menuName ="SO/Leveling/LevelUpOption",order = 0)]
public class LevelUpOption : ScriptableObject
{
    public string stat;

    public int level;

    public float multiplier;

    public int maxLevel;

    public string description;

    public PlayerStats pS;

    private void Start()
    {

    }
    public void GiveBonus(ref float targetStat)
    {
        targetStat += multiplier;
    }

}
