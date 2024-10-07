using UnityEngine;

public class SphereIdleState : SphereBaseState
{
    public override void Awake(SphereStateManager sphere)
    {
        Debug.Log("A mimir asies... Z Z Z Z Z Z Z Z Z Z");
    }

    public override void Execute(SphereStateManager sphere)
    {
        if (sphere.energy < sphere.maxEnergy)
        {
            sphere.energy += Time.deltaTime;
            Debug.Log(sphere.energy);
        }
        else
        {
            sphere.SwitchState(sphere.patrolState);
        }
    }

    public override void Sleep(SphereStateManager sphere)
    {
        Debug.Log("Bye from the IDLE STATE!");
    }
}
