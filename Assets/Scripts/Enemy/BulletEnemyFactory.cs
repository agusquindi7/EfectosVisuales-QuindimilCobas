using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyFactory : IBulletEnemyFactory
{
    private GameObject bulletPrefab;
    private int maxBullets;
    private int currentBullets;

    public BulletEnemyFactory(GameObject bulletPrefab)
    {
        this.bulletPrefab = bulletPrefab;
    }

    public void SetMaxBullets(int maxBullets)
    {
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
            return null;
        }
    }

    public void ActivateBullet(EnemyBullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    public void DeactivateBullet(EnemyBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}