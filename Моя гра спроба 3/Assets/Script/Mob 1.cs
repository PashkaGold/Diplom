using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob1 : MonoBehaviour
{
    public float speed;

    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    private void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
    }

    private void Update()
    {
        MoveTowardsSpot();
        CheckIfReachedSpot();
    }

    private void MoveTowardsSpot()
    {
        if (IsPathBlocked())
        {
            FindNewSpot();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        }
    }

    private void CheckIfReachedSpot()
    {
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                FindNewSpot();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void FindNewSpot()
    {
        int attempts = 0;
        int maxAttempts = 10; // ћаксимальна к≥льк≥сть спроб знайти нову точку

        do
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            attempts++;
        }
        while (IsPathBlocked() && attempts < maxAttempts);
    }

    private bool IsPathBlocked()
    {
        Vector2 direction = moveSpots[randomSpot].position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude);

        if (hit.collider != null && hit.collider.gameObject != gameObject)
        {
            // якщо Ї коллайдер, ≥ це не сам моб, то шл€х заблокований
            return true;
        }
        return false;
    }
}
