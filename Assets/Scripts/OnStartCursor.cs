using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartCursor : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
        Cursor.visible = true; // Hace el cursor visible
    }
}
