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
    public Controls _controls;
    private int hability;

    //public PlayerAttack(float cdShoot, float cdShootReload, Transform bulletSpawner, int ammo, Factory<Bullet> bulletFactory, Controls controls)
    public PlayerAttack(float cdShoot, float cdShootReload, Transform bulletSpawner, int ammo, Factory<Bullet> bulletFactory)
    {
        _cdShoot = cdShoot;
        _cdShootReload = cdShootReload;
        _bulletSpawner = bulletSpawner;
        _ammo = ammo;
        factory = bulletFactory;
        //_controls = controls;
    }

    public void SetControls(Controls controls)
    {
        _controls = controls;
    }

    public void ArtificialUpdate()
    {
        hability = _controls.GetHability();
        ReloadCooldown();
        Debug.Log("hability es " + hability);
    }

    public void Shoot() //QUITE LA MUNICION PORQUE NO HACIA FALTA
    {
        if (hability == 0)          //0 SHOOT, 1 JUMP
        {
            //else if (_ammo > 0 && _cdShootReload >= _cdShoot)
            if (_cdShootReload >= _cdShoot)
            {
                var s = factory.Create(); //creo la bala con la factory
                s.transform.position = _bulletSpawner.position;
                s.transform.rotation = _bulletSpawner.rotation;

                //_ammo--;
                _cdShootReload = 0;
            }
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
