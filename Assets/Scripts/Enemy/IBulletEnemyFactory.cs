using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletEnemyFactory
{
    EnemyBullet CreateBullet();
    void ActivateBullet(EnemyBullet bullet);
    void DeactivateBullet(EnemyBullet bullet);
    void SetMaxBullets(int maxBullets);
}