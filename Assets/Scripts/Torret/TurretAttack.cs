using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    //float _cdShoot;
    //float _cdShootReload;

    public Transform bulletSpawner;
    public float cdShoot = 1f;
    public float cdShootReload = 0f;

    Transform _bulletSpawner;

    //public Factory<Bullet> factory;

    public GameObject turretBullet;

    //public TurretAttack(float cdShoot, float cdShootReload, Transform bulletSpawner) //Factory<Bullet> bulletFactory
    //{
    //    _cdShoot = cdShoot;
    //    _cdShootReload = cdShootReload;
    //    _bulletSpawner = bulletSpawner;
    //    //factory = bulletFactory;

    //}

    private void Update()
    {
        ReloadCooldown();
        //Shoot();
    }

    public void Shoot()
    {
        if (cdShootReload >= cdShoot)
        {
            //var s = factory.Create(); //creo la bala con la factory
            //s.transform.position = _bulletSpawner.position;
            //s.transform.rotation = _bulletSpawner.rotation;

            Instantiate(turretBullet, bulletSpawner);
            Debug.Log("DISPARA");
            cdShootReload = 0;
        }
    }

    //public void ReloadCooldown(float deltaTime) //el time se lo puede pasar el Player o puedo usar el mismo de este script, da lo mismo
    public void ReloadCooldown()
    {
        if (cdShootReload < cdShoot)
            cdShootReload += Time.deltaTime;
    }
}
