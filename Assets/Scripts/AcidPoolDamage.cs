using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPoolDamage : MonoBehaviour
{
    [SerializeField] float damageAcidPool;
    [SerializeField] FumesAntidote fumesAntidote;

    private void OnTriggerStay(Collider other)
    {
        if (this.gameObject.name == "FirstFumesVolume")
        {
            if (other.GetComponent<PlayerLife>() && !fumesAntidote.HasDrankTheAntidote())
            {
                other.GetComponent<PlayerLife>().TakeDamage(damageAcidPool * Time.deltaTime);
            }
        }
        if (this.gameObject.name == "Box Volume")
        {
            if (other.GetComponent<PlayerLife>())
            {
                other.GetComponent<PlayerLife>().TakeDamage(damageAcidPool * Time.deltaTime);
            }
        }
    }
}
