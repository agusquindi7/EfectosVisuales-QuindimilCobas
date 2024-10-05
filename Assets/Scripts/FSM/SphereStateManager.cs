using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereStateManager : MonoBehaviour
{
    SphereBaseState currentState;
    public SphereIdleState idleState = new SphereIdleState();
    public SphereAttackingState attackingState = new SphereAttackingState();
    public SphereDeathState deathState = new SphereDeathState();

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
}
