using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLight : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Light light = GetComponentInChildren<Light>();
        
        if (collision.gameObject.GetComponent<Player>() && light != null)
        {
            Destroy(light.gameObject);
        }
    }
}
