using UnityEngine;

public class Mobatak : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float visionDistance;

    public Transform[] moveSpots;
    public Transform player;

    private int currentSpot = 0;
    private bool isChasing = false;
    private bool isAtSpot = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float playerDistance = Vector2.Distance(transform.position, player.position);

        if (playerDistance < stoppingDistance)
        {
            isChasing = true;
        }
        else if (playerDistance > visionDistance)
        {
            isChasing = false;
            isAtSpot = false;
        }

        if (isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            if (!isAtSpot)
            {
                MoveToNextSpot();
            }
        }
    }

    void MoveToNextSpot()
    {
        Vector2 targetPosition = moveSpots[currentSpot].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.2f)
        {
            currentSpot = (currentSpot + 1) % moveSpots.Length;
            isAtSpot = true;
        }
    }
}
