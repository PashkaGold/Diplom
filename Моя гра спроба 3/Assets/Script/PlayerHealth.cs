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
    public TMP_Text HealthLvl;
    private int Lvl = 0;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Text()
    {
        HealthLvl.text = $"Lvl Health: {Lvl}";
    }

    public void ChangeHealth()
    {
        if (Lvl <= 6 && Int32.Parse(GoldText.text) >= 10)
        {
            maxHealth += 10;
            Debug.Log("Покращення");
            Lvl++;
        }
        Text();
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
