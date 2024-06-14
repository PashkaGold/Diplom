using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int sceneIndex;
    public TMP_Text GoldText;

    private void Start()
    {
        currentHealth = maxHealth; // Встановлюємо початкове здоров'я рівним максимальному
    }

    public void ChangeHealse()
    {
        if (Int32.Parse(GoldText.text) >= 10)
        {
            maxHealth += 10;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Зменшуємо поточне здоров'я на величину отриманого урону

        // Перевіряємо, чи здоров'я стало менше або дорівнює нулю
        if (currentHealth <= 0)
        {
            Die(); // Якщо так, викликаємо метод Die()
        }
    }

    void Die()
    {
        // Ваш код для обробки смерті персонажа
        Debug.Log("Player died!");

        // Перехід на наступну сцену (використовуємо наступну сцену в порядку їх додавання до build settings)
        SceneManager.LoadScene(sceneIndex);
    }
}
