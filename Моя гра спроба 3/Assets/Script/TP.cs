using UnityEngine;
using UnityEngine.SceneManagement;

public class TP : MonoBehaviour
{
    // Публічна змінна для вказівки індексу сцени
    public int sceneIndex;

    // Метод, який викликається, коли інший об'єкт входить в тригер
    private void OnTriggerEnter(Collider other)
    {
        // Перевіряємо, чи об'єкт, що входить в тригер, є гравцем
        if (other.CompareTag("Player"))
        {
            // Перевіряємо, чи встановлений правильний індекс сцени
            if (sceneIndex >= 0)
            {
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                Debug.LogError("Scene index is not set correctly in the SceneChangeTrigger script.");
            }
        }
    }
}
