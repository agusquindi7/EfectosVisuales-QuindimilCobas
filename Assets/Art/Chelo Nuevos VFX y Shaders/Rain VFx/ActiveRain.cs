using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ActiveRain : MonoBehaviour
{
    public VisualEffect vfxRAIN;
    public GameObject objective;
    public GameObject triggerRain;

    //private void Start()
    private void Awake()
    {
        //gameObject.SetActive(false);
        //vfxRAIN.gameObject.SetActive(true);
        vfxRAIN.Stop();
        triggerRain.SetActive(false);

    }

    private void Update()
    {
        if (!objective.activeInHierarchy)
        {
            Debug.Log("el objetivo murio, prendiendo");
            //vfxRAIN.gameObject.SetActive(true);
            vfxRAIN.Play();
            triggerRain.SetActive(true);
        }
    }
}
