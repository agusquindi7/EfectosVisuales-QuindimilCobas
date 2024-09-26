using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ColliderChecker : MonoBehaviour
{
    bool isOnInteractuable;
    IInteractuable currentInteractuable;
    [SerializeField] KeyCode interactKey;
    [SerializeField] TextMeshProUGUI textInteractuable;

    private void Start()
    {
        textInteractuable.text = "Press " + interactKey + " to open" ;
    }

    public void Update()
    {
        if(isOnInteractuable && Input.GetKeyDown(interactKey))
        {   //Si estoy dentro del interactuable y apreto tal tecla, interactuar, en este caso voy a hacer que se apage la puerta laser, como no quiero que se vuelva a prender la dejo asi
            textInteractuable.enabled = false;
            currentInteractuable.Interact();        
        }
    }

    private void OnTriggerEnter(Collider other)
    {   //Si mi player toca el trigger que tiene IInteractuable entonces isOn se prende
        if(other.GetComponent<IInteractuable>() != null)
        {
            textInteractuable.enabled = true;
            IInteractuable interactuable = other.GetComponent<IInteractuable>();
            GetInteractuable(interactuable);
            isOnInteractuable = true;
        }
    }

    public void GetInteractuable(IInteractuable interactuable)
    {   //Almaceno el valor del interactuable en una variable local
        currentInteractuable = interactuable;
    }

    private void OnTriggerExit(Collider other)
    {   //Sino, se apaga
        if (other.GetComponent<IInteractuable>() != null)
        {
            textInteractuable.enabled = false;
            isOnInteractuable = false;
        }
    }
}
