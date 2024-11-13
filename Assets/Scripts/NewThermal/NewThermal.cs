using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewThermal : MonoBehaviour , IInteractuable
{
    public Animator animHD;
    ParticleSystem sparks;

    private void Start()
    {
        if (sparks == null) sparks = GetComponentInChildren<ParticleSystem>();
    }

    public void Interact()
    {
        sparks.Stop(true);
        animHD.SetTrigger("isOn");
    }
}
