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

    public PlayerStats stats;


    private void Start()
    {
        stats = GameObject.FindObjectOfType<PlayerStats>();
    }

    /// <summary>
    /// Compares SO's "stat" to cases in switch to adjust player stat
    /// </summary>
    public void GiveBonus()
    {
        switch (stat.ToLower())
        {
            case "damage":
                PlayerStats.damageMult += multiplier;
                break;
            case "speed":
                PlayerStats.speedMult += multiplier;
                break;
            case "health":
                PlayerStats.healthMult += multiplier;
                break;
            case "defense":
                PlayerStats.defenseMult += multiplier;
                break;
            case "regen":
                PlayerStats.regenMulti += multiplier;
                break;
            case "attack speed":
                PlayerStats.attackSpeedMult += multiplier;
                break;
            case "bullet speed":
                PlayerStats.bulletSpeedMult += multiplier;
                break;
            default:
                break;
        }

        level++;
    }


    public void OnReset()
    {
        level = 0;
    }

}
