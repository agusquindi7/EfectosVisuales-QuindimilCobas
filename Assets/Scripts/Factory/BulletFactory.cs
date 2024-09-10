using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : Factory<Bullet>
{
    public Bullet playerBullet;
    public override Bullet Create() //tiene que devolver una bullet obligatoriamente
    {
        return Instantiate(playerBullet);
    }
}
