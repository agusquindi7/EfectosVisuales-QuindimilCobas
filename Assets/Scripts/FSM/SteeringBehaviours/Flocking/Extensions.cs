using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Vector3 IgnoreY(this Vector3 v3)
    {
        v3.y = 0;
        return v3;
    }
}
