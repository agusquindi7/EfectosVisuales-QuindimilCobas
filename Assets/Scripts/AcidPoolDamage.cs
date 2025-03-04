using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPoolDamage : MonoBehaviour
{
    [SerializeField] float damageAcidPool;

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<PlayerLife>())
        {
            other.GetComponent<PlayerLife>().TakeDamage(damageAcidPool*Time.deltaTime);
        }
    }
}
