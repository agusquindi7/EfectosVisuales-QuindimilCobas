using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour, IInteractuable
{
    public void Interact()
    {
        this.gameObject.SetActive(false);
    }
}
