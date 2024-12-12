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
        statsBox.text = "Damage: " + (damage * damageMult) +"(mult: " + damageMult + ")" +
                        "\nDefense: " + (defense * defenseMult) + "(mult: " + defenseMult + ")" +
                        "\nHealth: " + (maxHealth * healthMult) + "(mult: " + healthMult + ")" +
                        "\nHealth Regen: " + (healthRegen * regenMulti) + "(mult: " +regenMulti + ")" +
                        "\nAttack Speed:" + (attackSpeed * attackSpeedMult) + "(mult: " + attackSpeedMult + ")" +
                        "\nRange: " + (range * rangeMult) + "(mult: " + rangeMult + ")" +
                        "\nSpeed: " + (speed * speedMult) + "(mult: " + speedMult + ")" +
                        "\nProjectiles: " + projectileNumber +
                        "\nBullet Modifiers: ";
        foreach (BulletModifier modifier in modifiers)
        {
            statsBox.text += modifier.upgradeName + ", ";
        }

    }

    /// <summary>
    /// Clears bullet modifiers
    /// </summary>
    public static void ClearModifiers()
    {
        modifiers.Clear();
    }

    /// <summary>
    /// Resets stat multipliers when called (usually on level load)
    /// </summary>
    public static void OnReset()
    {
        damageMult = 1.0f;
        speedMult = 1.0f;
        defenseMult = 1.0f;
        healthMult = 1.0f;
        rangeMult = 1.0f;
        bulletSpeedMult = 1.0f;
        attackSpeedMult = 1.0f;
        rangeMult = 1.0f;
        projectileNumber = 1;
        pierce = 1;
        ClearModifiers();
    }
}
