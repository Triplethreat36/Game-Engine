using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBarImage;
    public PlayerHealth playerHealth;

    void Start()
    {
        // Subscribe to the OnHealthChanged event
        playerHealth.OnHealthChanged += UpdateHealthBar;
        
    }

    void UpdateHealthBar(float health)
    {
        // Ensure health value is clamped between 0 and MAX_HEALTH
        float clampedHealth = Mathf.Clamp(health, 0f, PlayerHealth.MAX_HEALTH);

        // Update the image fill amount based on the player's health
        healthBarImage.fillAmount = clampedHealth / PlayerHealth.MAX_HEALTH;
        // Update the image fill amount based on the player's health
        
    }

    void OnDestroy()
    {
        // Unsubscribe from the event to prevent memory leaks
        playerHealth.OnHealthChanged -= UpdateHealthBar;
    }
}
