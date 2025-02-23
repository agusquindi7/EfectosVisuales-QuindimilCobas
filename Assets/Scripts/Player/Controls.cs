using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls
{
    Movement _movement;
    PlayerAttack _playerAttack;
    //private bool _isJumping;
    private bool isAiming; //bool del script para que permita apuntar y no mover al pesonaje

    //para funcionar le pido un movement y el playerattack
    //public Controls(Movement movement, PlayerAttack playerAttack, bool isJumping)

    private enum HabilityMode
    {
        Shoot,  //modo disparo
        Jump    //modo salto
    }
    private HabilityMode currentHability = HabilityMode.Shoot; //el enum esta inicializado en shoot

    public Controls(Movement movement, PlayerAttack playerAttack)
    {
        _movement = movement;
        _playerAttack = playerAttack;


        //_isJumping = isJumping;

        //PAUSA
        //ManagerPause.instance.Subscribe(ArtificialUpdate);
    }

    public void ArtificialUpdate() //SE REVIZAN LOS CONTROLES EN EL UPDATE DEL PLAYER
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var mouseX = Input.GetAxisRaw("Mouse X");
        var mouseY = Input.GetAxisRaw("Mouse Y");

        //PODRIA METER ACA EL if (!isAiming?) y me ahorro de pasarlo por script el bool porque hago el chequeo aca, o queda mal?

        #region Cambiar Habilidades 
        //si quiero que cambie con una sola tecla puedo usar un operador ternario y listo
        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    currentAbility = currentAbility == AbilityMode.Shoot ? AbilityMode.Jump : AbilityMode.Shoot;
        //    Debug.Log("Modo actual: " + currentAbility);
        //}

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentHability = HabilityMode.Shoot;
            Debug.Log("Modo actual: " + currentHability);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentHability = HabilityMode.Jump;
            Debug.Log("Modo actual: " + currentHability);
        }
        #endregion Cambiar Habilidades

        if (horizontal != 0 || vertical != 0) _movement.Move(horizontal, vertical);
        if (mouseX != 0) _movement.Rotate(mouseX); //rota al jugador con el mouse en el eje X

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
            ////public bool IsAttacking()
            //if (Input.GetKeyDown(KeyCode.Space)) //TIRARSE: PROXIMAMENTE
            //{
            //    _movement.CanonBall();
            //    Debug.Log("SE LANZA");
            //}
            ////}
            if (Input.GetKeyDown(KeyCode.Space)) _movement.Jump(); //SALTO         
        }
    }

    public bool IsAiming() //con esto le hago saber a otros scripts si la variable es T/F
    {
        return isAiming;
    }
    public float GetMouseX() //devuelvo el getaxisraw x del mouse
    {
        return Input.GetAxisRaw("Mouse X");
    }
    public float GetMouseY() //devuelvo el getaxisrwaw y del mouse
    {
        return Input.GetAxisRaw("Mouse Y");
    }
    public float GetHorizontal()
    {
        return Input.GetAxisRaw("Horizontal");
    }
    public float GetVertical()
    {
        return Input.GetAxisRaw("Vertical");
    }
    public int GetHability()
    {
        return (int)currentHability;
    }
    //Tuve 5 opciones: 1- hacer el enum publico
    //2- un struct publico que devuelva el int o string, pero de ambas se pierde, con int es menos legible pero es mas eficiente que string y string mantiene lo legible pero consume mas que int
    //public struct HabilityTypes
    //{
    //    public const int Shoot = 0;
    //    public const int Jump = 1;
    //    public const string Shoot = "Shoot";
    //    public const string Jump = "Jump";
    //}    
    //3- dejarlo privado y usar otra variable publica int igualandola, pero lo mismo de antes
    //4- podria usar .ToString al devolver en el metodo pero es lo mismo de antes
    //public string GetHability()
    //{
    //    return currentHability.ToString();
    //}
    //5- la que hice finalmente , devolver int xd
}
