using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Controls _controls;
    PlayerAttack _playerAttack;
    Movement _movement;

    [SerializeField] Rigidbody rb;

    public Transform bulletSpawner;

    public float speed = 5f;
    public float forceJump = 3f;

    public float cdShoot = 1f;
    public float cdShootReload = 0f;
    public int ammo = 10;
    public Factory<Bullet> factory;

    void Awake()
    {
        _movement = new Movement(transform, rb, speed, forceJump);
        _playerAttack = new PlayerAttack(cdShoot, cdShootReload, bulletSpawner, ammo, factory);        
        _controls = new Controls(_movement, _playerAttack);        
    }

    void Update()
    {
        _controls.ArtificialUpdate();
        //_playerAttack.ReloadCooldown(Time.deltaTime);
        _playerAttack.ReloadCooldown();
    }
}
