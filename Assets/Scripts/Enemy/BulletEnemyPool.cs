using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyPool : MonoBehaviour, IBulletEnemyPool
{
    [SerializeField]
    private int maxBullets = 20;

    private readonly Stack<EnemyBullet> objects = new Stack<EnemyBullet>();
    private IBulletEnemyFactory factory;

    public void Initialize(IBulletEnemyFactory factory)
    {
        this.factory = factory;
        factory.SetMaxBullets(maxBullets);

        for (int i = 0; i < maxBullets; i++)
        {
            EnemyBullet bullet = factory.CreateBullet();
            if (bullet != null)
            {
                objects.Push(bullet);
                factory.DeactivateBullet(bullet);
            }
            else
            {
            }
        }
    }

    public EnemyBullet Get()
    {
        if (objects.Count > 0)
        {
            EnemyBullet bullet = objects.Pop();
            factory.ActivateBullet(bullet);
            return bullet;
        }
        else
        {
            EnemyBullet bullet = factory.CreateBullet();
            if (bullet != null)
            {
                factory.ActivateBullet(bullet);
            }
            return bullet;
        }
    }

    public void Return(EnemyBullet bullet)
    {
        factory.DeactivateBullet(bullet);
        objects.Push(bullet);
    }
}