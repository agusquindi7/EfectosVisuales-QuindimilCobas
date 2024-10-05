using UnityEngine;

public abstract class SphereBaseState
{
    //Esta clase va a ser abstracta y va a tener referencia de todos los estados
    public abstract void Awake(SphereStateManager sphere);

    public abstract void Execute(SphereStateManager sphere);

    public abstract void Sleep(SphereStateManager sphere);
}
