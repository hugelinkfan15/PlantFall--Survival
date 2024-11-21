using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
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

    private void OnCollisionEnter2D(Collision2D collision)  
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            LevelUpManager.exp += collision.gameObject.GetComponent<ExpMover>().value;
            Destroy(collision.gameObject);
        }
    }
}
