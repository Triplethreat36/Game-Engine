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
        gameObject.SetActive(false);

        // Activate the button on the canvas (assuming you have a reference to it)
        canvasButton.SetActive(true);

    }
    public GameObject canvasButton;
    void Start()
    {
        GameManager.AddRestartEventListener(ResetHealth);
    }
    public void ResetHealth()
    {
        health = MAX_HEALTH; // Reset health to maximum value
        OnHealthChanged?.Invoke(health); // Raise the OnHealthChanged event with the new health value
        gameObject.SetActive(true);
        canvasButton.SetActive(false);

    }

}
