using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger2D : MonoBehaviour
{
    // Публічна змінна для вказівки індексу сцени
    public int sceneIndex;
    // Публічна змінна для вказівки тегу, який буде перевірятися
    public string triggerTag = "Player";

    // Метод, який викликається, коли інший об'єкт входить у тригер
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name); // Додано для відладки

        // Перевіряємо, чи об'єкт, що входить у тригер, має заданий тег
        if (other.CompareTag(triggerTag))
        {
            Debug.Log("Player detected, loading scene index: " + sceneIndex); // Додано для відладки
            // Завантажуємо сцену з вказаним індексом
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
