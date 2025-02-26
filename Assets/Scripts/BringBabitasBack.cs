using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringBabitasBack : MonoBehaviour
{
    public Transform babitas;
    public void BringBabitas()
    {
        Debug.Log("Trayendo a babitas...");
        babitas.transform.position = transform.position;
    }
}
