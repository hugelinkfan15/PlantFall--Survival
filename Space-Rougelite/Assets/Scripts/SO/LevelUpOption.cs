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

    }

    public void OnReset()
    {
        level = 0;
    }

}
