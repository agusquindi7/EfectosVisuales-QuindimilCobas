using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearTrigger : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDissapear>() != null)
        {
            other.GetComponent<IDissapear>().Dissapear();
        }
    }
}
