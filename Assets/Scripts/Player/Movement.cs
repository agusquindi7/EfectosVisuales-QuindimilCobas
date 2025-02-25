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
    private Transform _bulletSpawner;
    private bool _isJumping;
    private float _jumpHeight;
    private float _jumpDistance;
    private float _adjustmentSpeed; //Velocidad de ajuste para la distancia y altura
    private float _minDistance;
    private float _maxDistance;
    private float _minHeight;
    private float _maxHeight;
    private Vector3 _velocity;
    private LineRenderer _lineRenderer;
    private int _maxLineSegments;
    private float _raycastDistance;
    private LayerMask _groundLayer;

    private bool lineShow = false;
    private int hability = 0;

    //al no heredar de monobehabiour se lo pido todo a player en el constructor
    public Movement(Transform transform, Rigidbody rb, float speed, float rotationSpeed, Transform bulletSpawner, float launchForce,
        bool isJumping, Vector3 velocity, LineRenderer lineRenderer, int maxLineSegments, float raycastDistance, LayerMask groundLayer, float jumpHeight, float jumpDistance,
        float adjustmentSpeed, float minDistance, float maxDistance, float minHeight, float maxHeight)
    {
        _transform = transform;
        _rb = rb;
        _speed = speed;
        _rotationSpeed = rotationSpeed;
        _bulletSpawner = bulletSpawner;
        _launchForce = launchForce;
        
        _isJumping = isJumping;
        _jumpHeight = jumpHeight;
        _jumpDistance = jumpDistance;
        
        _adjustmentSpeed = adjustmentSpeed;
        _minDistance = minDistance;
        _maxDistance = maxDistance;
        _minHeight = minHeight;
        _maxHeight = maxHeight;
        
        _velocity = velocity;
        _lineRenderer = lineRenderer;
        _maxLineSegments = maxLineSegments;        
        _raycastDistance = raycastDistance;
        _groundLayer = groundLayer;

        //_canMove = canMove; //con la interfaz de ICanMove?
    }

    public void UpdateCannonValues(float speed, float launchForce)
    {
        _speed = speed;
        _launchForce = launchForce;
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
        if (!_controls.IsAiming() || _isJumping == true) //si mantiene el click derecho no se puede mover || si esta saltando tampoco puede moverse
        {
            var dir = _transform.forward * vertical;
            dir += _transform.right * horizontal;
            Vector3 newPosition = _rb.position + dir.normalized * _speed * Time.deltaTime;
            _rb.MovePosition(newPosition);
        }
    }

    public bool LineView()
    {
        // Se muestra solo si está apuntando y NO está saltando
        //lineShow = _controls.IsAiming() && !_isJumping;
        lineShow = _controls.IsAiming() && !_isJumping && hability == 1;
        _lineRenderer.enabled = lineShow;

        Debug.Log("lineShow es: " + lineShow);
        return lineShow;
    }

    public void UpdateJumpValue()
    {
        //Ajusta la distancia con el eje horizontal (A/D o flechas)
        float horizontalInput = Input.GetAxis("Horizontal");
        _jumpDistance = Mathf.Clamp(_jumpDistance + horizontalInput * _adjustmentSpeed * Time.deltaTime, _minDistance, _maxDistance);

        //Ajusta la altura con el eje vertical (W/S o flechas)
        float verticalInput = Input.GetAxis("Vertical");
        _jumpHeight = Mathf.Clamp(_jumpHeight + verticalInput * _adjustmentSpeed * Time.deltaTime, _minHeight, _maxHeight);
    }

    //PROBLEMA DE ROTACION
    //no se si es por lerp o por late update, al rotar a veces tarda un poco o vibra    
    public void Rotate(float cameraRotation) //sincronizo la rotacion del jugador con la rotacion horizontal de la cámara
    {        
        Quaternion targetRotation = Quaternion.Euler(0, cameraRotation, 0);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }

    public void CanonBall() //salto normal con impulse, se cambia a futuro como una pelota de golf
    {        
        Vector3 direction = _bulletSpawner.forward; //usa el vector forward del spawner para la direccion
        _rb.AddForce(direction * _launchForce, ForceMode.Impulse);   
    }

    //public bool IsGrounded()
    //{
    //    return Physics.Raycast(_transform.position, Vector3.down, _raycastDistance, _groundLayer);
    //}
    
    public void ArtificialdUpdate()
    {
        hability = _controls.GetHability();
        if (_controls.IsAiming() || _isJumping == true) UpdateJumpValue();

        //si es verdadero 
        if (_isJumping)
        {
            //si el raycast choca con el suelo, el bool es falso y la velocidad es 0
            if (Physics.Raycast(_transform.position, Vector3.down, _raycastDistance, _groundLayer) && _velocity.y < 0)
            //if (IsGrounded() && _velocity.y < 0)
            {
                Debug.Log("el salto es " + _isJumping);
                _isJumping = false;
                _velocity = Vector3.zero;
            }
        }

        LineView();
        //Actualiza la trayectoria constantemente para visualizar el salto
        UpdateTrajectory();
    }

    public void ArtificialFixedUpdate()
    {
        //si esta saltando le doy gravedad al rigid para ajustar la trayectoria hacia abajo
        if (_isJumping)
        {
            //velocity.y += gravity * Time.fixedDeltaTime;
            _velocity.y += Physics.gravity.y * Time.fixedDeltaTime;
            _rb.MovePosition(_transform.position + _velocity * Time.fixedDeltaTime);
        }
    }

    public void Jump()
    {
        if (!_isJumping)
        {
        _isJumping = true;
        //float initialYVelocity = Mathf.Sqrt(2 * -gravity * jumpHeight);
        float initialYVelocity = Mathf.Sqrt(2 * -Physics.gravity.y * _jumpHeight);
        //float initialHorizontalVelocity = jumpDistance / Mathf.Sqrt(2 * jumpHeight / -gravity);
        float initialHorizontalVelocity = _jumpDistance / Mathf.Sqrt(2 * _jumpHeight / -Physics.gravity.y);

        _velocity = _transform.forward * initialHorizontalVelocity;
        _velocity.y = initialYVelocity;
        }
    }

    private void UpdateTrajectory() //Se actualiza constantemente la visualizacion de la trayectoria
    {
        //Calcula la velocidad inicial para el salto
        //float initialYVelocity = Mathf.Sqrt(2 * -gravity * jumpHeight);
        float initialYVelocity = Mathf.Sqrt(2 * -Physics.gravity.y * _jumpHeight);
        //float initialHorizontalVelocity = jumpDistance / Mathf.Sqrt(2 * jumpHeight / -gravity);
        float initialHorizontalVelocity = _jumpDistance / Mathf.Sqrt(2 * _jumpHeight / -Physics.gravity.y);
        Vector3 initialVelocity = _transform.forward * initialHorizontalVelocity + Vector3.up * initialYVelocity;

        //Calculo los puntos de la trayectoria
        _lineRenderer.positionCount = _maxLineSegments;
        Vector3[] points = new Vector3[_maxLineSegments];

        Vector3 startPosition = _transform.position;
        for (int i = 0; i < _maxLineSegments; i++)
        {
            float time = i / (float)(_maxLineSegments - 1);
            points[i] = CalculateTrajectoryPoint(startPosition, initialVelocity, time);
        }
        _lineRenderer.SetPositions(points);
    }

    private Vector3 CalculateTrajectoryPoint(Vector3 startPosition, Vector3 initialVelocity, float time)
    {
        //ecuacion de la posicion en funcion del tiempo para una trayectoria parabola
        //Vector3 displacement = initialVelocity * time + 0.5f * new Vector3(0, gravity, 0) * time * time;
        Vector3 displacement = initialVelocity * time + 0.5f * new Vector3(0, Physics.gravity.y, 0) * time * time;
        return startPosition + displacement;
    }

    public bool GetJump()
    {
        return _isJumping;
    }
}
