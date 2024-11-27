using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ColliderChecker : MonoBehaviour
{
    [SerializeField] float radius = 2;
    //IInteractuable currentInteractuable;
    [SerializeField] KeyCode interactKey;
    [SerializeField] LayerMask interactuables;
    [SerializeField] TextMeshProUGUI textInteractuable;
    private void Start()
    {
        textInteractuable.text = "Press " + interactKey + " to open";
        textInteractuable.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, interactuables);
        if (colliders != null) 
        {
            foreach (Collider col in colliders)
            {
                //textInteractuable.enabled = true;
                IInteractuable interact = col.GetComponent<IInteractuable>();
                if (Input.GetKeyDown(interactKey))
                {
                    interact.Interact();
                    //textInteractuable.enabled = false;
                }
            }
        }
    }

    //public void PhysicsMethod()
    //{
    //    Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
    //    if(colliders!=null) textInteractuable.enabled = true;
    //    else textInteractuable.enabled = true;
    //    foreach (Collider col in colliders)
    //    {
    //        IInteractuable interact = col.GetComponent<IInteractuable>();
    //        if(Input.GetKeyDown(interactKey)) interact.Interact();
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    //public void GetInteractuable(IInteractuable interactuable)
    //{   //Almaceno el valor del interactuable en una variable local
    //    currentInteractuable = interactuable;
    //}
    //private void OnTriggerExit(Collider other)
    //{   //Sino, se apaga
    //    if (other.GetComponent<IInteractuable>() != null)
    //    {
    //        textInteractuable.enabled = false;
    //        isOnInteractuable = false;
    //    }
    //}
}