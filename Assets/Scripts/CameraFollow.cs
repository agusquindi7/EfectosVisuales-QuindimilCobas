using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow
{
    // Mantener el código tal cual
    private Transform _player;
    private Transform _camera;
    private float _distance;
    private float _aimDistance;
    private float _height;
    private float _rotationSpeed;
    private float _sensitivity;
    private float _cameraSmoothness;
    private float _verticalAngleMin;
    private float _verticalAngleMax;
    private Controls _controls;

    private float currentDistance;
    private float horizontalRotation;
    private float verticalRotation;
    private float currentVerticalRotation;

    public CameraFollow(Transform player, Transform camera, float distance,
        float aimDistance, float height, float rotationSpeed, float sensitivity,
        float cameraSmoothness, float verticalAngleMin, float verticalAngleMax, Controls controls)
    {
        _player = player;
        _camera = camera;
        _distance = distance;
        _aimDistance = aimDistance;
        _height = height;
        _rotationSpeed = rotationSpeed;
        _sensitivity = sensitivity;
        _cameraSmoothness = cameraSmoothness;
        _verticalAngleMin = verticalAngleMin;
        _verticalAngleMax = verticalAngleMax;
        _controls = controls;

        currentDistance = distance;
        horizontalRotation = camera.eulerAngles.y;
        verticalRotation = camera.eulerAngles.x;
    }

    //esto es por si quiero actualizar valores en el update de Player
    public void UpdateValues(float distance, float aimDistance, float height,
        float rotationSpeed, float sensitivity, float cameraSmoothness,
        float verticalAngleMin, float verticalAngleMax)
    {
        _distance = distance;
        _aimDistance = aimDistance;
        _height = height;
        _rotationSpeed = rotationSpeed;
        _sensitivity = sensitivity;
        _cameraSmoothness = cameraSmoothness;
        _verticalAngleMin = verticalAngleMin;
        _verticalAngleMax = verticalAngleMax;
        currentDistance = distance;
    }

    public float GetHorizontalRotation()
    {
        return horizontalRotation;
    }

    public void LateUpdate()
    {
        RotateCamera();

        Vector3 desiredPosition = CalculateCameraPosition();
        _camera.position = Vector3.Lerp(_camera.position, desiredPosition, _cameraSmoothness);

        // La cámara mira al jugador
        _camera.LookAt(_player.position + Vector3.up * _height);
    }

    private void RotateCamera()
    {
        float mouseX = _controls.GetMouseX() * _rotationSpeed * _sensitivity;
        float mouseY = _controls.GetMouseY() * _rotationSpeed * _sensitivity;

        horizontalRotation += mouseX;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, _verticalAngleMin, _verticalAngleMax);

        currentVerticalRotation = Mathf.Lerp(currentVerticalRotation, verticalRotation, _cameraSmoothness);
    }

    private Vector3 CalculateCameraPosition()
    {
        Quaternion rotation = Quaternion.Euler(currentVerticalRotation, horizontalRotation, 0f);
        Vector3 offset = new Vector3(0, _height, -currentDistance); // Usar currentDistance para interpolar
        return _player.position + rotation * offset;
    }



    /*
     * SCRIPT DE HOY ORIGINAL QUE TENIA MIO, AGREGAR MONOBEHAVIOUR
     * 
     * 
    public Transform player;
    public float distance = 4f; // Distancia normal
    public float aimDistance = 3f; // Distancia al apuntar
    public float height = 2f;
    public float rotationSpeed = 5f;
    public float sensitivity = 1f;
    public float cameraSmoothness = 0.1f;
    public float verticalAngleMin = -10f;
    public float verticalAngleMax = 60f;

    private float currentDistance; // La distancia actual (para interpolar)
    private float horizontalRotation;
    private float verticalRotation;
    private float currentVerticalRotation;
    private Controls playerInput;

    void Start()
    {
        // Inicializamos la distancia actual con la distancia normal
        currentDistance = distance;
        //playerInput = player.GetComponent<Controls>();

        horizontalRotation = transform.eulerAngles.y;
        verticalRotation = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        //// Si estamos apuntando, ajustamos la distancia de la cámara
        //if (playerInput.IsAiming())
        //{
        //    currentDistance = Mathf.Lerp(currentDistance, aimDistance, cameraSmoothness); // Acercar la cámara
        //}
        //else
        //{
        //    currentDistance = Mathf.Lerp(currentDistance, distance, cameraSmoothness); // Alejar la cámara
        //}

        RotateCamera();

        Vector3 desiredPosition = CalculateCameraPosition();
        transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraSmoothness);

        // Mirar al jugador
        transform.LookAt(player.position + Vector3.up * height);
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * sensitivity;

        horizontalRotation += mouseX;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, verticalAngleMin, verticalAngleMax);

        currentVerticalRotation = Mathf.Lerp(currentVerticalRotation, verticalRotation, cameraSmoothness);
    }

    private Vector3 CalculateCameraPosition()
    {
        Quaternion rotation = Quaternion.Euler(currentVerticalRotation, horizontalRotation, 0f);
        Vector3 offset = new Vector3(0, height, -currentDistance); // Usar currentDistance para interpolar
        return player.position + rotation * offset;
    }

    */




    /*
    public Transform player; // El transform del jugador al que sigue la cámara

    public float distance = 4f; // Distancia desde la cámara al jugador
    public float height = 2f; // Altura de la cámara respecto al jugador
    public float rotationSpeed = 5f; // Velocidad de rotación de la cámara
    public float sensitivity = 1f; // Sensibilidad del mouse para la rotación
    public float cameraSmoothness = 0.1f; // Suavidad en la rotación de la cámara
    public float verticalAngleMin = -10f; // Ángulo mínimo de rotación vertical
    public float verticalAngleMax = 60f; // Ángulo máximo de rotación vertical

    private float horizontalRotation;
    private float verticalRotation;
    private float currentVerticalRotation;

    void Start()
    {
        // Inicializar las rotaciones según la posición inicial de la cámara
        horizontalRotation = transform.eulerAngles.y;
        verticalRotation = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        // Rotar la cámara según el movimiento del mouse
        RotateCamera();

        // Mantener la cámara alineada con el jugador
        Vector3 desiredPosition = CalculateCameraPosition();
        transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraSmoothness);

        // Siempre apuntar hacia el jugador
        transform.LookAt(player.position + Vector3.up * height);
    }

    private void RotateCamera()
    {
        // Obtener la entrada del ratón, ajustada por la sensibilidad
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * sensitivity;

        // Ajustar la rotación horizontal (en el eje Y)
        horizontalRotation += mouseX;

        // Ajustar la rotación vertical (en el eje X) y limitarla para evitar giros completos
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, verticalAngleMin, verticalAngleMax);

        // Aplicar la rotación suave usando Lerp para una transición más fluida
        currentVerticalRotation = Mathf.Lerp(currentVerticalRotation, verticalRotation, cameraSmoothness);
    }

    private Vector3 CalculateCameraPosition()
    {
        // Calcular la posición deseada de la cámara basado en la rotación y el offset
        Quaternion rotation = Quaternion.Euler(currentVerticalRotation, horizontalRotation, 0f);
        Vector3 offset = new Vector3(0, height, -distance);
        return player.position + rotation * offset;
    }
    */

    /*
    public Transform player;        // Referencia al transform del jugador
    public float distance = 5.0f;   // Distancia entre la cámara y el jugador
    public float height = 2.0f;     // Altura de la cámara respecto al jugador
    public float sensitivity = 5.0f; // Sensibilidad del movimiento del mouse
    public float rotationSmoothness = 0.1f; // Suavidad de la rotación

    private float currentX = 0.0f;  // Rotación actual en el eje X
    private float currentY = 0.0f;  // Rotación actual en el eje Y
    private Vector3 desiredPosition;

    void Start()
    {
        if (!player)
        {
            Debug.LogError("Player Transform is not assigned in the CameraFollowPlayer script.");
        }
    }

    void Update()
    {
        // Obtener la rotación en los ejes X e Y basadas en el movimiento del mouse
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;

        // Restringir la rotación en Y (vertical) para evitar rotaciones invertidas
        currentY = Mathf.Clamp(currentY, -60, 60);

        // Calcular la posición deseada de la cámara
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        desiredPosition = player.position + rotation * new Vector3(0, height, -distance);
    }

    void LateUpdate()
    {
        // Mover la cámara a la posición deseada
        transform.position = desiredPosition;

        // Rotar la cámara para que apunte hacia el jugador
        transform.LookAt(player.position + Vector3.up * height);
    }
    */

    /*
    //asigno objetivo
    public Transform target;
    public Camera myCamera;

    //si quiero offset de camara
    //public float offset = 3;
    //Vector3 _offsetDir;

    //tamaño de la camara en una variable
    public float cameraView;

    private void Awake()
    {
        //el target sera el que tenga el tag player, si es que no esta puesto
        if (target == null) target = GameObject.FindGameObjectWithTag("Player").transform;

        //if (myCamera == null) myCamera = GetComponent<Camera>();
        //la camara va a ser la main, la main tiene esta propiedad del .main
        if (myCamera == null) myCamera = Camera.main;

    }
    // Start is called before the first frame update
    void Start()
    {
        //el tamaño de la camara la igualo a la variable que quiero
        Camera.main.orthographicSize = cameraView;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //_offsetDir = target.right;
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

            //Con offset
            //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z) + offset * _offsetDir;
        }

        //si no hay personaje, el script deja de funcionar para ahorrar recursos
        else Destroy(this);
    }
    */
}