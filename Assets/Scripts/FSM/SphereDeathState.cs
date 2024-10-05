using UnityEngine;

public class SphereDeathState : SphereBaseState
{
    public override void Awake(SphereStateManager sphere)
    {
        Debug.Log("Hello from the... X(");
        Animator animator = sphere.GetComponent<Animator>();
        animator.SetTrigger("isDeath");
    }

    public override void Execute(SphereStateManager sphere)
    {
        
    }

    public override void Sleep(SphereStateManager sphere)
    {
        Debug.Log("*Dead noises*");
    }
}
