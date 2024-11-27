using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Sanguijuelas : MonoBehaviour
{
    [SerializeField] VisualEffect sanguijuelas;

    private void Start()
    {
        sanguijuelas.SendEvent("OnStop");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerLife>())
        {
            sanguijuelas.SendEvent("OnPlay");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerLife>())
        {
            sanguijuelas.SendEvent("OnStop");
        }
    }
}
