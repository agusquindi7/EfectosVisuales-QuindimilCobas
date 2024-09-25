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

    //lo pongo en un script aparte para que no se inicialice antes los controles y no haya problemas de nulos    
    public void SetControls(Controls controls)
    {
        _controls = controls;
    }

    //public bool CanMove()
    //{
    //    if (isAiming) return isAiming;
    //}

    //PROBLEMA: VIBRA UN POCO, INCLUSO EN LOS SALTOS SE NOTA ESTO
    public void Move(float horizontal, float vertical)
    {
        if (!_controls.IsAiming()) //si mantiene el click derecho no se puede mover
        {
            var dir = _transform.forward * vertical;
            dir += _transform.right * horizontal;

            //_transform.position = dir.normalized * _speed * Time.deltaTime;
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
    //CHAT GPT
    public void Rotate(float cameraRotation)
    {
        // Sincronizamos la rotación del jugador con la rotación horizontal de la cámara
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



        //CHATGPT
        
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








    /*
    public float moveSpeed = 5f;
    public Transform cameraTransform; // Referencia al Transform de la cámara
    private Controls playerInput;

    void Start()
    {
        playerInput = GetComponent<Controls>();
    }

    void Update()
    {
        Vector3 movementInput = playerInput.GetMovementInput();
        Move(movementInput);
    }

    private void Move(Vector3 direction)
    {
        // Convertir la dirección del movimiento al espacio de la cámara
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        // Asegurar que la dirección sea solo en el plano horizontal (Y=0)
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalizar los vectores para evitar que la velocidad cambie con la dirección
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Direccionar el movimiento basado en la orientación de la cámara
        Vector3 desiredDirection = cameraForward * direction.z + cameraRight * direction.x;

        // Rotar el jugador para que mire en la dirección del movimiento
        if (desiredDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(desiredDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
        }

        // Mover el jugador en la dirección deseada
        transform.Translate(desiredDirection * moveSpeed * Time.deltaTime, Space.World);
    }*/

    /*
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f; // Ajusta la velocidad de rotación
    public float rotationSmoothness = 0.1f; // Suavidad de la rotación

    private Controls playerInput;
    private Transform cameraTransform; // Referencia a la cámara principal
    private float currentRotationY; // Almacena la rotación actual en el eje Y
    private float targetRotationY; // Almacena la rotación objetivo en el eje Y
    private float rotationVelocity; // Velocidad de la rotación

    void Start()
    {
        playerInput = GetComponent<Controls>();
        cameraTransform = Camera.main.transform; // Obtenemos la referencia a la cámara principal
        currentRotationY = transform.eulerAngles.y;
        targetRotationY = currentRotationY;
    }

    void Update()
    {
        Vector3 movement = playerInput.GetMovementInput();
        Move(movement);

        // Rotar el jugador y la cámara según el movimiento del mouse
        RotatePlayerAndCamera();
    }

    private void Move(Vector3 direction)
    {
        Vector3 moveDirection = transform.forward * direction.z + transform.right * direction.x;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    private void RotatePlayerAndCamera()
    {
        float mouseX = playerInput.GetMouseXInput();
        targetRotationY += mouseX * rotationSpeed;

        // Aplicar suavidad en la rotación usando Mathf.SmoothDampAngle
        currentRotationY = Mathf.SmoothDampAngle(currentRotationY, targetRotationY, ref rotationVelocity, rotationSmoothness);

        // Aplicar la rotación al jugador
        transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);

        // Aplicar la misma rotación a la cámara
        cameraTransform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);
    }
    */

    /*
    public float moveSpeed = 5f;
    private Controls playerInput; //podria ponerle Entities para respetar SOLID pero se que solo va a haber 1 control

    public float rotationSpeed = 10f; // Ajusta la velocidad de rotación
    public float rotationSmoothness = 0.1f; // Suavidad de la rotación

    private float currentRotationY; // Almacena la rotación actual en el eje Y
    private float targetRotationY; // Almacena la rotación objetivo en el eje Y
    private float rotationVelocity; // Velocidad de la rotación

    void Start()
    {        
        playerInput = GetComponent<Controls>();
        currentRotationY = transform.eulerAngles.y;
        targetRotationY = currentRotationY;
    }

    void Update()
    {
        Vector3 movement = playerInput.GetMovementInput();
        Move(movement);

        // Rotar el jugador según el movimiento del mouse
        RotatePlayer();
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        float mouseX = playerInput.GetMouseXInput();
        targetRotationY += mouseX * rotationSpeed;

        // Aplicar suavidad en la rotación usando Mathf.SmoothDampAngle
        currentRotationY = Mathf.SmoothDampAngle(currentRotationY, targetRotationY, ref rotationVelocity, rotationSmoothness);

        // Aplicar la rotación al jugador
        transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);
    }
    */
}
