using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "SO/Tracker/PlayerStats", order = 0)]
public class PlayerStats : ScriptableObject
{

    public TextMeshProUGUI statsBox;
    //BASE VALUES
    public static float damage;

    public static float speed;

    public static float maxHealth;

    public static float pickupRange;

    public static float defense;

    public static float healthRegen;

    public static float range;

    public static float bulletSpeed;

    public static float attackSpeed;

    public static int projectileNumber;

    public static int pierce;

    //PERCENTAGE MODIFIERS
    public static float damageMult = 1.0f;

    public static float speedMult = 1.0f;

    public static float defenseMult = 1.0f;

    public static float healthMult = 1.0f;

    public static float rangeMult = 1.0f;

    public static float bulletSpeedMult = 1.0f;

    public static float attackSpeedMult = 1.0f;

    public static float regenMulti = 1.0f;

    public static List<BulletModifier> modifiers = new List<BulletModifier>();

    public void Display()
    {
        statsBox.text = "Damage: " + damage + " * " + damageMult +
                        "\nDefense: " + defense + " * " + defenseMult +
                        "\nHealth: " + maxHealth + " * " + healthMult +
                        "\nHealth Regen: " + healthRegen + " * " + regenMulti +
                        "\nAttack Speed:" + attackSpeed + " * " + attackSpeedMult +
                        "\nRange: " + range + " * " + rangeMult +
                        "\nSpeed: " + speed + " * " + speedMult +
                        "\nProjectiles: " + projectileNumber;
    }

    public void ClearModifiers()
    {
        modifiers.Clear();
    }


}
