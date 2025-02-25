using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory2 : Factory2<Bullet2> //ESTA ES DEL PLAYER
{
    public Bullet2 turretBullet;

    ObjectPool2<Bullet2> _pool2;

    public void Awake()
    {
        _pool2 = new ObjectPool2<Bullet2>(GetInstantiate, TurnOn, TurnOff);
    }

    private void TurnOn(Bullet2 bullet)
    {
        bullet.TurnOn();
    }
    private void TurnOff(Bullet2 bullet)
    {
        bullet.TurnOff();
    }

    private Bullet2 GetInstantiate()
    {
        return Instantiate(turretBullet);
    }

    public override Bullet2 Create() //tiene que devolver una bullet obligatoriamente            
    {
        if (turretBullet == null)
        {
            Debug.LogError("no se asigno bala");
            return null;
        }

        //???
        var b = _pool2.Get();
        b.Pool2 = _pool2;
        return b;
        //return Instantiate(playerBullet);
        //return _pool.Get;
    }
}