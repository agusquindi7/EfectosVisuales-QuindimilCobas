using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnemy : MonoBehaviour
{
    StateMachine<IState> _stateMachine;

    //private void Awake()
    //{
    //    _stateMachine = GetComponent<StateMachine<IState>>();
    //}

    private void Start()
    {
        _stateMachine = new StateMachine<IState>();

        _stateMachine.AddState(new IdleState());
        _stateMachine.AddState(new AttackingState());
    }

    private void Update()
    {
        _stateMachine.Update();

        if (Input.GetKeyDown(KeyCode.Space)) _stateMachine.SetState<AttackingState>();
        else if (Input.GetKeyDown(KeyCode.V)) _stateMachine.SetState<IdleState>();
    }
}
