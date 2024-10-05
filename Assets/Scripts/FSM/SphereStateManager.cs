using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereStateManager : MonoBehaviour
{
    SphereBaseState currentState;
    public SphereIdleState idleState = new SphereIdleState();
    public SpherePatrolState patrolState = new SpherePatrolState();
    public SphereChaseState chaseState = new SphereChaseState();
    //PatrolStateVariables
    public float energy = 0;
    public int currentWaypointIndex = 0;
    public float speed = 5;
    public Transform[] waypoints;
    //ChaseStateVariables
    public float radius = 4f;

    private void Start()
    {
        currentState = idleState;

        currentState.Awake(this);
    }

    private void Update()
    {
        currentState.Execute(this);
    }

    public void SwitchState(SphereBaseState state)
    {
        currentState.Sleep(this);
        currentState = state;
        currentState.Awake(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.red;
    }
}
