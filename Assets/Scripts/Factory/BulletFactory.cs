using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : Factory<Bullet>
{
    public Bullet playerBullet;

    ObjectPool<Bullet> _pool;

    public void Awake()
    {
        _pool = new ObjectPool<Bullet>(GetInstantiate, TurnOn, TurnOff);
    }

    private void TurnOn(Bullet bullet)
    {
        bullet.TurnOn();
    }
    private void TurnOff(Bullet bullet)
    {
        bullet.TurnOff();
    }

    private Bullet GetInstantiate()
    {
        return Instantiate(playerBullet);
    }

    public override Bullet Create() //tiene que devolver una bullet obligatoriamente            
    {
        if (playerBullet == null)
        {
            Debug.LogError("no se asigno bala");
            return null;
        }



        //???
        var b = _pool.Get();
        b.Pool = _pool;
        return b;
        //return Instantiate(playerBullet);
        //return _pool.Get;
    }
}
