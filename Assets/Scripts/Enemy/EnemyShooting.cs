using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour, IEnemyShooting
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int maxBullets = 20; // Máximo número de balas que la fábrica puede crear
    public float bulletLifetime = 5f; // Tiempo de vida de las balas

    private BulletEnemyPool bulletPool;
    private BulletEnemyFactory bulletFactory;

    void Start()
    {
        bulletFactory = new BulletEnemyFactory(bulletPrefab, maxBullets);
        bulletPool = new BulletEnemyPool(bulletFactory.CreateBullet, EnemyBullet.TurnOn, EnemyBullet.TurnOff, maxBullets);
    }

    public void Shoot()
    {
        EnemyBullet bullet = bulletPool.Get();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.gameObject.SetActive(true);
            StartCoroutine(DeactivateBulletAfterTime(bullet, bulletLifetime));
        }
    }

    private IEnumerator DeactivateBulletAfterTime(EnemyBullet bullet, float time)
    {
        yield return new WaitForSeconds(time);
        bulletPool.Return(bullet);
    }
}