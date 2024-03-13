using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public const float MAX_HEALTH = 100f;
    public float health = MAX_HEALTH;

    public event Action<float> OnHealthChanged;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
        OnHealthChanged?.Invoke(health); // Raise the OnHealthChanged event
    }

    void Die()
    {
        // Add any death logic here, such as game over or respawn
        Debug.Log("Player died.");
    }
}
