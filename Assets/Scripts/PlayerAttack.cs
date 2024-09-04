using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //haciendo esto evito pedir 2 clases a este script y hago que dependa de controles nomas. Pero todavia no respeta SOLID
    public float cd = 1.0f; //tiempo de recarga maxima
    private float cdReload = 0f;

    private Controls playerInput;

    void Start()
    {
        playerInput = GetComponent<Controls>();
    }

    void Update()
    {

        if (playerInput.IsAiming() && playerInput.IsAttacking() && cdReload >= cd)
        {
            Attack();
            Debug.Log("cd:  " + cdReload);
        }

        else if (cdReload < cd)
        {
            cdReload += Time.deltaTime;
        }
    }

    private void Attack()
    {
        cdReload = 0;
        Debug.Log("dispara!");
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
