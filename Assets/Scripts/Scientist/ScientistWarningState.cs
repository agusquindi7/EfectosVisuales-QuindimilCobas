using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistWarningState : ScientistBaseState
{
    public override void OnAwake(FSM_Manager sct)
    {
        sct.tmpro.text = "WARNING STATE";
        sct.tmpro.color = Color.red;
        sct.counter = 0;
    }

    public override void OnUpdate(FSM_Manager scientist)
    {

    }

    public override void OnExit(FSM_Manager scientist)
    {

    }
}
