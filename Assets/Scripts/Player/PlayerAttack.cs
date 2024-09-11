using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //haciendo esto de evitar la clase PlayerAim, evito pedir 2 clases a este script y hago que dependa de controles nomas. Pero todavia no respeta SOLID del todo

    public float cd = 1.0f; //tiempo de recarga maxima
    private float cdReload = 0f;
    [SerializeField] private int _ammo = 3;

    private Controls playerInput;
    //public Bullet playerBullet;
    //public BulletFactory factory; //aca estoy rompiendo Solid, dependo del padre
    public Factory<Bullet> factory; //aca estoy dependiendo de una abstraccion, y le cargue el tipo de generic que quiero

    void Start()
    {
        playerInput = GetComponent<Controls>();
    }

    void Update()
    {

        if (_ammo <= 0) return;

        else if (playerInput.IsAiming() && playerInput.IsAttacking() && cdReload >= cd)
        {
            _ammo--;
            Shoot();
            //Debug.Log("cd:  " + cdReload);
        }

        else if (cdReload < cd)
        {
            cdReload += Time.deltaTime;
        }
    }

    private void Shoot()
    {
        cdReload = 0;
        Debug.Log("dispara!");

        //Instantiate(playerBullet, transform.position, transform.rotation);
        var s = factory.Create();
        s.transform.position = transform.position;
        s.transform.forward = transform.forward;
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
