using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletEnemyPool
{
    EnemyBullet Get();
    void Return(EnemyBullet bullet);
}