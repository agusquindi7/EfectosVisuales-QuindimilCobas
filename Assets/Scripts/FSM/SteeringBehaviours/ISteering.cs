using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISteering
{
    Vector3 GetDir(Vector3 origin, Vector3 target);
}