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
    public float energy, maxEnergy = 10f;
    public int currentWaypointIndex = 0;
    public float speed = 5;
    public Transform[] waypoints;
    //ChaseStateVariables
    public float radius = 4f;
    public Transform target;
    public float maxSpeed;
    private ISteering steering;

    private void Start()
    {
        energy = maxEnergy;

        currentState = idleState;

        currentState.Awake(this);

        steering = new PursuitSteering(maxSpeed, radius, 1);
    }

    public void Pursuit()
    {
        Debug.Log("Siguiendo");
        transform.position += steering.GetDir(transform.position, target.position);
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
