using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpots : MonoBehaviour
{
    public float speed;
    public float radius;
    private Vector2 initialPosition;
    private float angle;

    private void Start()
    {
        initialPosition = transform.position;
        angle = Random.Range(0f, 360f);
    }

    private void Update()
    {
        float positionX = initialPosition.x + Mathf.Cos(angle) * radius;
        float positionY = initialPosition.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector2(positionX, positionY);
        angle += Time.deltaTime * speed;
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
