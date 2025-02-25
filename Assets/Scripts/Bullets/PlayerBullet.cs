using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    [SerializeField] float _duration = 3f; //lo que quiero que dure la bala
    [SerializeField] float _counter;     //el contador que suma por el tiempo

    //como se que todas las balas se van a poder reutilizar, hago una var publica
    //pero para pedir cuando vale sea protected, no vas a saber cuantas hay, solo vas a poder modificar de afuera, no pedir.
    //public ObjectPool<Bullet> Pool
    //{
    //    protected get; //todas las balas van a ser protected como privadas
    //    set; //pero si voy a poder modificarlo
    //}

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        _counter += Time.deltaTime;

        if (_counter >= _duration) Pool.Return(this);        
    }

    public override void TurnOff()
    {
        _counter = 0;
        base.TurnOff();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IActivable>() != null)
        {
            Debug.Log("golpeo a " + other);
            other.GetComponent<IActivable>().Activable();
        }
    }
}
