using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    Transform _transform;
    Rigidbody _rb;
    float _speed;
    float _forceJump;
    bool _canMove;
    float _rotationSpeed;
    float _launchForce;
    private Controls _controls;

    //MonoBehaviour _monoBehaviour;
    //public bool isAiming;

    //al no heredar de monobehabiour se lo pido todo a player en el constructor
    public Movement(Transform transform, Rigidbody rb, float speed,
        float forcejump, float rotationSpeed,float launchForce)
    //bool canMove, MonoBehaviour monoBehaviour          al no heredar de monobehaviour se lo pido a player
    {
        _transform = transform;
        _rb = rb;
        _speed = speed;
        _forceJump = forcejump;
        _rotationSpeed = rotationSpeed;

        //_canMove = canMove; //con la interfaz de ICanMove?
        //_controls = controls;
        //_monoBehaviour = monoBehaviour;
    }

    //el constructor con los paramentros se inicializa antes, por eso lo pongo en un script aparte
    //para quelos controles no se inicialice antes de eso y no haya problemas de nulos    
    public void SetControls(Controls controls)
    {
        _controls = controls;
    }

    //public bool CanMove()
    //{
    //    if (isAiming) return isAiming;
    //}

    public void Move(float horizontal, float vertical)
    {
        if (!_controls.IsAiming()) //si mantiene el click derecho no se puede mover
        {
            var dir = _transform.forward * vertical;
            dir += _transform.right * horizontal;
            Vector3 newPosition = _rb.position + dir.normalized * _speed * Time.deltaTime;
            _rb.MovePosition(newPosition);
        }        
    }

    //public void Rotate(float mouseX)
    //{
    //    if (_controls.IsAiming()) //rotación en el eje Y del jugador
    //        _transform.Rotate(Vector3.up * mouseX * _rotationSpeed * Time.deltaTime);        
    //}

    //PROBLEMA DE ROTACION
    //no se si es por lerp o por late update, al rotar a veces tarda un poco o vibra    
    public void Rotate(float cameraRotation)
    {
        //sincronizo la rotacion del jugador con la rotacion horizontal de la cámara
        Quaternion targetRotation = Quaternion.Euler(0, cameraRotation, 0);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }

    public void CanonBall()
    {
        //salto normal, se cambia a futuro como una pelota de golf
        _rb.AddForce(Vector3.up * _forceJump, ForceMode.Impulse);

        //if (_monoBehaviour == null)
        //{
        //    Debug.LogError("no tiene monobehaviour");
        //    return;
        //}        
        
        //// Calcular la dirección de lanzamiento
        //Vector3 launchDirection = Camera.main.transform.forward;
        //launchDirection.y = 0; // Elimina la componente vertical
        //launchDirection.Normalize(); // Normaliza el vector

        //// Debug para visualizar la dirección de lanzamiento
        //Debug.DrawRay(_transform.position, launchDirection * 10, Color.red, 2f);

        //// Aplicar fuerza al Rigidbody para lanzar al personaje
        //_rb.AddForce(launchDirection * _launchForce, ForceMode.Impulse);

        //// Opcional: Desactivar la gravedad temporalmente
        //_rb.useGravity = false;
        //_monoBehaviour.StartCoroutine(EnableGravityAfterTime(0.5f)); // Reactivar la gravedad después de medio segundo
    }

    //IEnumerator EnableGravityAfterTime(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    _rb.useGravity = true;
    //}    
}
