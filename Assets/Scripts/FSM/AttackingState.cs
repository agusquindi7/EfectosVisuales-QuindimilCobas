using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : IState
{
    public void Awake()
    {
        Debug.Log("AWAKE ATTACKING STATE");
    }

    public void Execute()
    {
        Debug.Log("ATTACKING...");
    }

    public void Sleep()
    {
        Debug.Log("SLEEP ATTACKING STATE");
    }
}
