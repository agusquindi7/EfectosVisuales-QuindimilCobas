using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ActiveRain : MonoBehaviour
{
    //public VisualEffect vfxRAIN;
    public VisualEffect [] vfxRains;
    public GameObject objective;
    //public GameObject triggerRain;
    public GameObject [] triggerRains;
    public bool onActive = false;

    //private void Start()
    private void Awake()
    {
        if (objective != null) //si quiero que se apague al principio solo le meto un objetivo
        {
            OffRain();
            OffTrigger();
            //vfxRAIN.Stop();
            //gameObject.SetActive(false);
            //vfxRAIN.gameObject.SetActive(true);
            //triggerRain.SetActive(false);
        }
        else
        {
            OnRain();
            OnTrigger();
        }
            //fxRAIN.Play();

    }

    private void Update()
    {
        if (objective != null)
        {
            if (!objective.activeInHierarchy) //si no esta activo en la jerarquia
            {
                //if (onActive == true) return;
                
                Debug.Log("el objetivo murio, prendiendo");
                //vfxRAIN.Play();
                OnRain();
                OnTrigger();
                //OnActive();
                //vfxRAIN.gameObject.SetActive(true);
                //triggerRain.SetActive(true);
            }            
        }       
    }

    public void OnActive()
    {
        onActive = !onActive;
    }

    public void OffRain()
    {
        for (int i = 0; i < vfxRains.Length; i++)
        {
            vfxRains[i].Stop();

        }
    }

    public void OnRain()
    {
        for (int i = 0; i < vfxRains.Length; i++)
        {
            vfxRains[i].Play();

        }
    }

    public void OnTrigger()
    {
        for (int i = 0; i < vfxRains.Length; i++)
        {
            triggerRains[i].SetActive(true);
        }
    }

    public void OffTrigger()
    {
        for (int i = 0; i < vfxRains.Length; i++)
        {
            triggerRains[i].SetActive(false);
        }
    }
}
