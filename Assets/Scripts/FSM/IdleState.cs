using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    StateMachine <IState> stateMachine;

    

    public void Awake()
    {
        Debug.Log("AWAKE IDLE STATE");
    }

    public void Execute()
    {
        Debug.Log("EXECUTING...");
    }

    public void Sleep()
    {
        Debug.Log("SLEEP IDLE STATE");
    }
}
