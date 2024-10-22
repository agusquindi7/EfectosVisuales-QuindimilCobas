using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : Bullet
{
    [SerializeField] float _duration = 3f; //lo que quiero que dure la bala
    [SerializeField] float _counter;     //el contador que suma por el tiempo

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        _counter += Time.deltaTime;

        //if (_counter >= _duration)
        //    Pool.Return(this);
    }

    public override void TurnOff()
    {
        _counter = 0;
        base.TurnOff();
    }
}
