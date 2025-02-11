using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxGizmo : MonoBehaviour
{
    public Vector3 center, size;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(center, size);
    }
}
