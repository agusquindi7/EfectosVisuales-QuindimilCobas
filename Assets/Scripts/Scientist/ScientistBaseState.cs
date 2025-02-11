using UnityEngine;

public abstract class ScientistBaseState
{
    public abstract void OnAwake(FSM_Manager sct);
    public abstract void OnUpdate(FSM_Manager sct);
    public abstract void OnExit(FSM_Manager sct);
}
