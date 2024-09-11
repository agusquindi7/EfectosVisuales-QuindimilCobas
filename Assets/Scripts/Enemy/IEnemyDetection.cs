using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyDetection
{
    bool IsPlayerInRange { get; }
    Transform Player { get; }
}
