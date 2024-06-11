using UnityEngine;
using UnityEngine.AI;

public class EnemyAgres : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent not found!");
        }

        // Обмежуємо обертання агента
        agent.updateRotation = false;
    }

    void Update()
    {
        if (player != null && agent.isOnNavMesh)
        {
            agent.SetDestination(player.position);
            // Вирівнюємо бота у площині 2D
            Vector3 lookAtPlayer = player.position;
            lookAtPlayer.z = transform.position.z; // Фіксуємо положення по осі Z
            transform.LookAt(lookAtPlayer);
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z); // Фіксуємо обертання по осям X і Y
        }
    }
}
