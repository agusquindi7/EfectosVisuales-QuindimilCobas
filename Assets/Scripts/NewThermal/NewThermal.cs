using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewThermal : MonoBehaviour , IInteractuable
{
    public Animator animHD, animThermal;
    ParticleSystem sparks;

    private void Start()
    {
        if (sparks == null) sparks = GetComponentInChildren<ParticleSystem>();
        if (animThermal == null) animThermal = GetComponent<Animator>();
    }

    public void Interact()
    {
        sparks.Stop(true);
        animHD.SetTrigger("isOn");
        animThermal.SetBool("isOn", true);
    }
}
