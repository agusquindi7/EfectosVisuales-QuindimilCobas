using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ActiveRain : MonoBehaviour
{
    public VisualEffect vfxRAIN;
    public GameObject objective;

    private void Start()
    {
        vfxRAIN.Stop();
    }

    private void Update()
    {
        if (!objective.activeInHierarchy)
        {
            vfxRAIN.Play();
        }
    }
}
