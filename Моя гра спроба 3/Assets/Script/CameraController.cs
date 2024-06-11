using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform; // Трансформ камери
    public Transform mapTransform; // Трансформ карти (наприклад, порожній об'єкт, що визначає розміри карти)
    public Vector2 mapSize; // Розміри карти (ширина і висота)

    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        // Якщо cameraTransform не заданий, використовуємо трансформ об'єкта, до якого прикріплений цей скрипт
        if (cameraTransform == null)
        {
            cameraTransform = transform;
        }

        // Обчислення половини висоти і ширини камери
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        // Обмеження позиції камери
        float clampedX = Mathf.Clamp(cameraTransform.position.x, mapTransform.position.x - mapSize.x / 2 + halfWidth, mapTransform.position.x + mapSize.x / 2 - halfWidth);
        float clampedY = Mathf.Clamp(cameraTransform.position.y, mapTransform.position.y - mapSize.y / 2 + halfHeight, mapTransform.position.y + mapSize.y / 2 - halfHeight);

        // Оновлення позиції камери
        cameraTransform.position = new Vector3(clampedX, clampedY, cameraTransform.position.z);
    }
}
