using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntigravityTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IAntigravity>() != null)
        {
            Debug.Log("entro el obj: " + other);
            other.GetComponent<IAntigravity>().Antigravity();
        }
    }
}
