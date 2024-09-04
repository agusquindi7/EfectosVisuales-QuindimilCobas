using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullets : MonoBehaviour
{
    //RequireComponent <BoxCollider>;
    public float damage = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamageable>() !=null)
        {
            other.GetComponent<IDamageable>().TakeDamage(damage);
        }            
    }
}
