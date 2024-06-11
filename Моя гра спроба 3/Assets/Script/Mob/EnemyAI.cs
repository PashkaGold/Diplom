using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using KnightAdventure.Utils;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;
    [SerializeField] private float roamingTimerMax = 2f;

    private NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private Vector3 roamPosition;
    private Vector3 startingPosition;

    public enum State // «роблено публ≥чним
    {
        Idle,
        Roaming
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        state = startingState;
        startingPosition = transform.position;
    }

    private void Start()
    {
        if (roamingDistanceMin > roamingDistanceMax)
        {
            float temp = roamingDistanceMin;
            roamingDistanceMin = roamingDistanceMax;
            roamingDistanceMax = temp;
        }
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Idle:
                break;
            case State.Roaming:
                roamingTime -= Time.deltaTime;
                if (roamingTime < 0)
                {
                    Roaming();
                    roamingTime = roamingTimerMax;
                }
                break;
        }
    }

    private void Roaming()
    {
        roamPosition = GetRoamingPosition();
        navMeshAgent.SetDestination(roamPosition);
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + Utils.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);
    }

    public void SetState(State newState)
    {
        state = newState;
    }
}
