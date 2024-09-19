using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyPool
{
    private readonly Stack<EnemyBullet> objects;
    private readonly Func<EnemyBullet> createFunc;
    private readonly Action<EnemyBullet> turnOnAction;
    private readonly Action<EnemyBullet> turnOffAction;

    public BulletEnemyPool(Func<EnemyBullet> createFunc, Action<EnemyBullet> turnOnAction, Action<EnemyBullet> turnOffAction, int initialCapacity)
    {
        this.createFunc = createFunc;
        this.turnOnAction = turnOnAction;
        this.turnOffAction = turnOffAction;
        objects = new Stack<EnemyBullet>(initialCapacity);
        for (int i = 0; i < initialCapacity; i++)
        {
            objects.Push(createFunc());
        }
    }

    public EnemyBullet Get()
    {
        if (objects.Count > 0)
        {
            EnemyBullet obj = objects.Pop();
            turnOnAction(obj);
            return obj;
        }
        else
        {
            EnemyBullet obj = createFunc();
            turnOnAction(obj);
            return obj;
        }
    }

    public void Return(EnemyBullet obj)
    {
        turnOffAction(obj);
        objects.Push(obj);
    }
}