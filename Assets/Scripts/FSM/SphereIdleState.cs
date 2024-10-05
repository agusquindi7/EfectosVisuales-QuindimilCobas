using UnityEngine;

public class SphereIdleState : SphereBaseState
{
    public override void Awake(SphereStateManager sphere)
    {
        Debug.Log("Hello from the IDLE STATE!\nPRESS SPACE BUTTON TO ATTACK");
    }

    public override void Execute(SphereStateManager sphere)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sphere.SwitchState(sphere.attackingState);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            sphere.SwitchState(sphere.deathState);
        }
    }

    public override void Sleep(SphereStateManager sphere)
    {
        Debug.Log("Bye from the IDLE STATE!");
    }
}
