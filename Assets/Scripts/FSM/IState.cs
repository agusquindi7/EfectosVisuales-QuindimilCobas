using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Awake();
    void Execute();
    void Sleep();
}
