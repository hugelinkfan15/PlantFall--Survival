using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "SO/Tracker/PlayerStats", order = 0)]
public class PlayerStats : ScriptableObject
{
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
}
