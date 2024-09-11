using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    //RequireComponent <BoxCollider>;
    [SerializeField] protected float _damage = 5f; //si fuera privada, nadie, ni sus hijos podrian acceder al daño
    [SerializeField] protected float _speed = 10f; //protected es privda para todos menos para los que hereden

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(_damage);
        }
    }    
}
