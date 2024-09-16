using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls
{
    Movement _movement;
    PlayerAttack _playerAttack;

    public Controls(Movement movement, PlayerAttack playerAttack) //para funcionar le pido un movement y el playerattack
    //public Controls(Movement movement) //para funcionar le pido un movement
    {
        _movement = movement;
        _playerAttack = playerAttack;
    }

    public void ArtificialUpdate() //SE REVIZAN LOS CONTROLES EN EL UPDATE DEL PLAYER
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            _movement.Move(horizontal, vertical);
        }

        //public bool IsAiming()
        if (Input.GetMouseButton(1)) //Solo al mantener presionado dispara //APUNTAR
        {
            // Si se mantiene el botón derecho, permitir disparar con el clic izquierdo
            if (Input.GetMouseButtonDown(0)) //DISPARAR BALA
            {
                _playerAttack.Shoot();
            }

            //public bool IsAttacking()
            if (Input.GetKeyDown(KeyCode.Space)) //TIRARSE PROXIMAMENTE
            {
                _movement.CanonBall();
            }
        }
        //if (!Input.GetMouseButton(1))
    }
}
