using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "SO/Tracker/PlayerStats", order = 0)]
public class PlayerStats : ScriptableObject
{
    //BASE VALUES
    public static float damage;

    public static float speed;

    public static float maxHealth;

    public static float pickupRange;

    public static float defense;

    public static float healthRegen;

    public static float currentHealth;

    public static float range;

    public static float bulletSpeed;

    public static float attackSpeed;

    //PERCENTAGE MODIFIERS
    public static float damageMult = 1.0f;

    public static float speedMult = 1.0f;

    public static float defenseMult = 1.0f;

    public static float healthMult = 1.0f;

    public static float rangeMult = 1.0f;

    public static float bulletSpeedMult = 1.0f;

    public static float attackSpeedMult = 1.0f;

}
