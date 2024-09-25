using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    //RequireComponent <BoxCollider>;
    [SerializeField] protected float _damage = 5f; //si fuera privada, nadie, ni sus hijos podrian acceder al daño
    [SerializeField] protected float _speed = 10f; //protected es privda para todos menos para los que hereden

    
    //como se que todas las balas se van a poder reutilizar, hago una var publica
    //pero para pedir cuando vale sea protected, no vas a saber cuantas hay, solo vas a poder modificar de afuera, no pedir.
    public ObjectPool<Bullet> Pool
    {
        protected get; //todas las balas van a ser protected como privadas
        set; //pero si voy a poder modificarlo
    }

    /*
    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        //Destroy(gameObject, 3);
    }
    */

    public virtual void TurnOn()
    {
        gameObject.SetActive(true);
    }

    public virtual void TurnOff()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(_damage);
        }
    }
    

}
