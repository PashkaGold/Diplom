using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TMP_Text GoldText;
    public int sceneIndex;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth()
    {
        if (Int32.Parse(GoldText.text) >= 10)
        {
            maxHealth += 10;
            Debug.Log("Покращення");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        SceneManager.LoadScene(sceneIndex); // Перехід на іншу сцену при смерті гравця
    }
}
