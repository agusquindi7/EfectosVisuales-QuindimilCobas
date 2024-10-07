using UnityEngine;

public class SphereAttackingState : SphereBaseState
{
    public override void Awake(SphereStateManager sphere)
    {
        Animator animator = sphere.GetComponent<Animator>();
        Debug.Log("Hello from the ATTACKING STATE!");
        animator.SetTrigger("isAttacking");
    }

    public override void Execute(SphereStateManager sphere)
    {
        sphere.SwitchState(sphere.idleState);
    }

    public override void Sleep(SphereStateManager sphere)
    {
        Debug.Log("Bye from the ATTACKING STATE!");
    }
}
