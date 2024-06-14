using UnityEngine;
using GatheringCounter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AtakPlayer : MonoBehaviour
{
    [SerializeField]
    Transform center;

    [SerializeField]
    float radius = 2f, angularSpeed = 2f;
    public TMP_Text GoldText;
    float positionX, positionY, angle = 0f;

    public void ChangeSpeedGun()
    {
        if (Int32.Parse(GoldText.text) >= 10)
        {
            angularSpeed += 0.1f;
        }
    }

    void Update()
    {
        // Розраховуємо позицію об'єкта по колу
        positionX = center.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        positionY = center.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
        transform.position = new Vector2(positionX, positionY);

        // Збільшуємо кут
        angle += Time.deltaTime * angularSpeed;

        // Перевіряємо, чи кут перевищив 360 градусів
        if (angle >= 360f)
        {
            angle -= 360f; // Запобігаємо переповненню
        }

    }
}