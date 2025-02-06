using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLight : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Light light = GetComponentInChildren<Light>();
            Destroy(light.gameObject);
        }
    }
}
