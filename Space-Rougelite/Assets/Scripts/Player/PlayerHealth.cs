using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Transactions;
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
    public Animator animator;

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

    /// <summary>
    /// Damage is dealt as damage-defense
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        if (damage - defense < 1)
        {
            currentHealth -= 1;
        }
        else
        {
            currentHealth -= (damage - defense);
        }
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
        StartCoroutine(HandleDeath());
        
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

    /*private void OnCollisionEnter2D(Collision2D collision)  
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            LevelUpManager.exp += collision.gameObject.GetComponent<ExpMover>().value;
            Destroy(collision.gameObject);
        }
    }*/

    IEnumerator PlayerDeath()
    {
        Debug.Log("PlayerDead = True");
        animator.SetBool("PlayerDead", true);
        yield return new WaitForSeconds(2);
        animator.SetBool("PlayerDead", false);
    }

    IEnumerator HandleDeath()
    {
        yield return StartCoroutine(PlayerDeath());
        gameObject.SetActive(false);
        GameManager.Instance.gameOver = true;
    }
}
