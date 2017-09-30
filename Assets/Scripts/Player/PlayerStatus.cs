using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    [SerializeField]
    int baseMaxHealth;

    int maxHealth;
    int currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth = baseMaxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Current Health: " + currentHealth);
        
        if (currentHealth <= 0)
        {
            // TODO: Don't just destroy the player when he dies
            Destroy(gameObject);
        }
    }

    public void ApplyHealing(int healAmount)
    {
        currentHealth += healAmount;

        currentHealth = currentHealth > maxHealth ? maxHealth : currentHealth;
    }
}
