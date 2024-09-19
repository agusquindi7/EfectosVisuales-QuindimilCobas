using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyFactory
{
    private GameObject bulletPrefab;
    private int maxBullets;
    private int currentBullets;

    public BulletEnemyFactory(GameObject bulletPrefab, int maxBullets)
    {
        this.bulletPrefab = bulletPrefab;
        this.maxBullets = maxBullets;
        this.currentBullets = 0;
    }

    public EnemyBullet CreateBullet()
    {
        if (currentBullets < maxBullets)
        {
            GameObject bulletObject = Object.Instantiate(bulletPrefab);
            currentBullets++;
            return bulletObject.GetComponent<EnemyBullet>();
        }
        else
        {
            return null; // O manejar de otra manera cuando se alcanza el límite
        }
    }
}