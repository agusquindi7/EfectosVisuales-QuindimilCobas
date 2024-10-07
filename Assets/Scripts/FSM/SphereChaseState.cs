using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChaseState : SphereBaseState
{
    public override void Awake(SphereStateManager sphere)
    {
        Debug.Log("OS VOY A ROMPER A PEDAZOOOS!");
    }

    public override void Execute(SphereStateManager sphere)
    {
        sphere.Pursuit();
        Collider[] colliders = Physics.OverlapSphere(sphere.transform.position, sphere.radius);
        foreach (Collider collider in colliders)
        {
            Debug.Log(collider.name);
            if (collider.GetComponent<PlayerLife>() && Vector3.Distance(collider.transform.position, sphere.transform.position) > sphere.radius)
            {
                sphere.SwitchState(sphere.patrolState);
            }
        }
    }

    public override void Sleep(SphereStateManager sphere)
    {
        Debug.Log("onde ta? ;(");
    }
}
