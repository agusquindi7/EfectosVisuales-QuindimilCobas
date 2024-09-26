using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls
{
    Movement _movement;
    PlayerAttack _playerAttack;

    private bool isAiming; //bool del script para que permita apuntar y no mover al pesonaje

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
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");


        if (horizontal != 0 || vertical != 0)
            _movement.Move(horizontal, vertical);

        if (mouseX != 0) //rota al jugador con el mouse en el eje X
            _movement.Rotate(mouseX);


        isAiming = Input.GetMouseButton(1); //la variale bool se activa solo al mantener el click derecho mouse
       
        if (isAiming)  //si es true permito disparar con el clic izquierdo o lanzarme
        {
            Debug.Log("apunta");
            //if (Input.GetMouseButton(1)) //Solo al mantener presionado dispara //APUNTAR
            //{                
            if (Input.GetMouseButtonDown(0)) //DISPARAR BALA
            {
                _playerAttack.Shoot();
                Debug.Log("DISPARA");
            }
            //public bool IsAttacking()
            if (Input.GetKeyDown(KeyCode.Space)) //TIRARSE: PROXIMAMENTE
            {
                _movement.CanonBall();
                Debug.Log("SE LANZA");
            }
            //}
        }
    }

    public bool IsAiming() //con esto le hago saber a otros scripts si la variable es T/F
    {        
        return isAiming;
    }

    public float GetMouseX() //devuelvo el getaxis x del mouse
    {
        return Input.GetAxis("Mouse X");
    }
    public float GetMouseY()
    {
        return Input.GetAxis("Mouse Y"); //devuelvo el getaxis y del mouse
    }

}
