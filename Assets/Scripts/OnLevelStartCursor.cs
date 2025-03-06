using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelStartCursor : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; // Desbloquea el cursor
        Cursor.visible = false; // Hace el cursor visible
    }
}
