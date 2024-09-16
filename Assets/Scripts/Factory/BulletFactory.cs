using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : Factory<Bullet>
{
    public Bullet playerBullet;
    public override Bullet Create() //tiene que devolver una bullet obligatoriamente
    {
        if (playerBullet == null)
        {
            Debug.LogError("no se asigno bala");
            return null;
        }

        return Instantiate(playerBullet);
    }
}
