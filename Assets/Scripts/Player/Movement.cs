using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform; // Referencia al Transform de la c�mara
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
        // Convertir la direcci�n del movimiento al espacio de la c�mara
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        // Asegurar que la direcci�n sea solo en el plano horizontal (Y=0)
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalizar los vectores para evitar que la velocidad cambie con la direcci�n
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Direccionar el movimiento basado en la orientaci�n de la c�mara
        Vector3 desiredDirection = cameraForward * direction.z + cameraRight * direction.x;

        // Rotar el jugador para que mire en la direcci�n del movimiento
        if (desiredDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(desiredDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
        }

        // Mover el jugador en la direcci�n deseada
        transform.Translate(desiredDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    /*
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f; // Ajusta la velocidad de rotaci�n
    public float rotationSmoothness = 0.1f; // Suavidad de la rotaci�n

    private Controls playerInput;
    private Transform cameraTransform; // Referencia a la c�mara principal
    private float currentRotationY; // Almacena la rotaci�n actual en el eje Y
    private float targetRotationY; // Almacena la rotaci�n objetivo en el eje Y
    private float rotationVelocity; // Velocidad de la rotaci�n

    void Start()
    {
        playerInput = GetComponent<Controls>();
        cameraTransform = Camera.main.transform; // Obtenemos la referencia a la c�mara principal
        currentRotationY = transform.eulerAngles.y;
        targetRotationY = currentRotationY;
    }

    void Update()
    {
        Vector3 movement = playerInput.GetMovementInput();
        Move(movement);

        // Rotar el jugador y la c�mara seg�n el movimiento del mouse
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

        // Aplicar suavidad en la rotaci�n usando Mathf.SmoothDampAngle
        currentRotationY = Mathf.SmoothDampAngle(currentRotationY, targetRotationY, ref rotationVelocity, rotationSmoothness);

        // Aplicar la rotaci�n al jugador
        transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);

        // Aplicar la misma rotaci�n a la c�mara
        cameraTransform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);
    }
    */

    /*
    public float moveSpeed = 5f;
    private Controls playerInput; //podria ponerle Entities para respetar SOLID pero se que solo va a haber 1 control

    public float rotationSpeed = 10f; // Ajusta la velocidad de rotaci�n
    public float rotationSmoothness = 0.1f; // Suavidad de la rotaci�n

    private float currentRotationY; // Almacena la rotaci�n actual en el eje Y
    private float targetRotationY; // Almacena la rotaci�n objetivo en el eje Y
    private float rotationVelocity; // Velocidad de la rotaci�n

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

        // Rotar el jugador seg�n el movimiento del mouse
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

        // Aplicar suavidad en la rotaci�n usando Mathf.SmoothDampAngle
        currentRotationY = Mathf.SmoothDampAngle(currentRotationY, targetRotationY, ref rotationVelocity, rotationSmoothness);

        // Aplicar la rotaci�n al jugador
        transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);
    }
    */
}
