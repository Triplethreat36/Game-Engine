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
        // Update the image fill amount based on the player's health
        healthBarImage.fillAmount = health / PlayerHealth.MAX_HEALTH;
    }

    void OnDestroy()
    {
        // Unsubscribe from the event to prevent memory leaks
        playerHealth.OnHealthChanged -= UpdateHealthBar;
    }
}
