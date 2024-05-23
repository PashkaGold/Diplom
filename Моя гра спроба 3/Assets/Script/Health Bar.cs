using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth playerHealth; // Посилання на новий скрипт PlayerHealth

    private void Start()
    {
        if (playerHealth != null)
        {
            SetMaxHealth(playerHealth.maxHealth);
        }
        else
        {
            Debug.LogError("PlayerHealth not assigned in HealthBar.");
        }
    }

    private void Update()
    {
        if (playerHealth != null)
        {
            SetHealth(playerHealth.currentHealth);
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
