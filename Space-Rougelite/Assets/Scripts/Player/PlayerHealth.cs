using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

/// <summary>
/// Script for keeping track of Player's health. 
/// Should be attached to the Player Object
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public static float currentHealth;
    public float healing;
    public float defense;
    public DisplayBar healthBar;

    private bool isHealing;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        PlayerStats.maxHealth = maxHealth;
        PlayerStats.healthRegen = healing;
        PlayerStats.defense = defense;
        healthBar.SetMaxValue(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = PlayerStats.maxHealth * PlayerStats.healthMult;
        healing = PlayerStats.healthRegen * PlayerStats.regenMulti;
        defense = PlayerStats.defense * PlayerStats.defenseMult;

        healthBar.SetMaxValueOnly(maxHealth);

        if(currentHealth <= 0)
        {
            Die();
        }

        if(!isHealing && (currentHealth < maxHealth))
        {
            StartCoroutine(Heal());
        }

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetValue(currentHealth);
        if (!isHealing)
        {
            StartCoroutine(Heal());
        }
    }

    public static float GetHealth()
    {
        return currentHealth;
    }

    private void Die()
    {
        gameObject.SetActive(false);
        GameManager.Instance.gameOver = true;
    }

    /// <summary>
    /// Coroutine to heal the player every 1/10 of a second (healing is shown as per second though)
    /// </summary>
    /// <returns></returns>
    IEnumerator  Heal()
    {
        isHealing = true;

        while(currentHealth < maxHealth)
        {
            currentHealth += (healing/10);
            healthBar.SetValue(currentHealth);
            yield return new WaitForSeconds(0.1f);
        }

        isHealing=false;
    }

    private void OnCollisionEnter2D(Collision2D collision)  
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            LevelUpManager.exp += collision.gameObject.GetComponent<ExpMover>().value;
            Destroy(collision.gameObject);
        }
    }
}
