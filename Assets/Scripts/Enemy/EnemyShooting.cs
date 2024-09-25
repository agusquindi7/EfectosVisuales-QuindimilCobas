using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour, IEnemyShooting
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletLifetime = 5f;
    public float shootInterval = 1f;
    public int maxAmmo = 10;
    public float reloadTime = 5f;

    private IBulletEnemyPool bulletPool;
    private IBulletEnemyFactory bulletFactory;
    private EnemyDetection enemyDetection;
    private float shootTimer;
    private int currentAmmo;
    private bool isReloading = false;

    void Start()
    {        
        bulletFactory = new BulletEnemyFactory(bulletPrefab);
        
        bulletPool = gameObject.AddComponent<BulletEnemyPool>();
        ((BulletEnemyPool)bulletPool).Initialize(bulletFactory);
            
        enemyDetection = GetComponent<EnemyDetection>();

        if (enemyDetection == null)
        {
        }
        shootTimer = shootInterval;
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
            return;

        if (enemyDetection != null && enemyDetection.IsPlayerInRange)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = shootInterval;
            }
        }
        else
        {
            shootTimer = shootInterval;
        }
    }

    public void Shoot()
    {
        if (currentAmmo > 0)
        {
            EnemyBullet bullet = bulletPool.Get();
            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                StartCoroutine(DeactivateBulletAfterTime(bullet, bulletLifetime));
                currentAmmo--;
            }
            else
            {
            }
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    private IEnumerator DeactivateBulletAfterTime(EnemyBullet bullet, float time)
    {
        yield return new WaitForSeconds(time);
        bulletPool.Return(bullet);
    }
}