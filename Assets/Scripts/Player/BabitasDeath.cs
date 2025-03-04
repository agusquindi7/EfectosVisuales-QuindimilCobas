using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabitasDeath : MonoBehaviour
{
    public GameObject panel;

    public void DeathFunction()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        panel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
