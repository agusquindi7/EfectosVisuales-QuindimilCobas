using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class OnTriggerDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SphereCollider sphereTrigger = GetComponent<SphereCollider>();
        sphereTrigger.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
