using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack
{
    float _cdShoot;
    float _cdShootReload;
    int _ammo;
    Transform _bulletSpawner;    
    public Factory<Bullet> factory;

    public PlayerAttack(float cdShoot, float cdShootReload, Transform bulletSpawner, int ammo, Factory<Bullet> bulletFactory)
    {
        _cdShoot = cdShoot;
        _cdShootReload = cdShootReload;
        _bulletSpawner = bulletSpawner;
        _ammo = ammo;
        factory = bulletFactory; 
    }
    
    public void Shoot()
    {
        if (_ammo <= 0) return;
         
        else if (_ammo > 0 && _cdShootReload >= _cdShoot)
        {
            var s = factory.Create(); //creo la bala con la factory
            s.transform.position = _bulletSpawner.position;
            s.transform.rotation = _bulletSpawner.rotation;

            _ammo--;
            _cdShootReload = 0;
        }
    }

    //public void ReloadCooldown(float deltaTime) //el time se lo puede pasar el Player o puedo usar el mismo de este script, da lo mismo
    public void ReloadCooldown()
    {
        if (_cdShootReload < _cdShoot)
            _cdShootReload += Time.deltaTime;
    }
    
    //public float cd = 1f; //tiempo de recarga maxima
    //private float cdReaload = 0f;

    //private Controls playerInput; //podria ponerle Entities para respetar SOLID pero se que solo va a haber 1 control
    //private PlayerAim playerAim;

    //void Start()
    //{
    //    playerInput = GetComponent<Controls>();
    //    playerAim = GetComponent<PlayerAim>();
    //}

    //void Update()
    //{
    //    if (playerAim.IsAiming() && playerInput.IsAttacking() && Time.time >= cdReaload)
    //    {
    //        Attack();
    //        cdReaload = Time.time + cd; // Actualiza el tiempo del próximo disparo
    //    }
    //}

    //private void Attack()
    //{
    //    Debug.Log("Disparo realizado!");
    //}
}
