using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Controls _controls;
    PlayerAttack _playerAttack;
    Movement _movement;

    CameraFollow _cameraFollow;

    [SerializeField] Rigidbody rb;

    public Transform bulletSpawner;

    public float speed = 5f;
    public float forceJump = 3f;

    public float cdShoot = 1f;
    public float cdShootReload = 0f;
    public int ammo = 10;
    public Factory<Bullet> factory;


    public float launchForce = 10f;

    [SerializeField] private Transform cameraTransform; // Aquí referencia a la cámara principal

    public float rotationSpeed = 10f;

    // Parámetros para la cámara
    public float cameraDistance = 4f;
    public float aimCameraDistance = 3f;
    public float cameraHeight = 2f;
    public float cameraRotationSpeed = 4f;
    public float cameraSensitivity = 1f;
    public float cameraSmoothness = 0.1f;
    public float cameraVerticalAngleMin = -10f;
    public float cameraVerticalAngleMax = 60f;


    [SerializeField] bool _activeThisCamera;

    public MonoBehaviour monoBehaviour;

    void Awake()
    {
        cameraRotationSpeed = rotationSpeed;
        //si inicializo antes los controles hay problemas nulos, queres inicializar algo que no existe
        _playerAttack = new PlayerAttack(cdShoot, cdShootReload, bulletSpawner, ammo, factory);
        _movement = new Movement(transform, rb, speed, forceJump, rotationSpeed, launchForce); //monoBehaviour
        _controls = new Controls(_movement, _playerAttack);

        //entonces inicializo un metodo de controls luego de crear controls
        _movement.SetControls(_controls);

        _cameraFollow = new CameraFollow(transform, cameraTransform, cameraDistance, aimCameraDistance, cameraHeight,
                                         cameraRotationSpeed, cameraSensitivity, cameraSmoothness,
                                         cameraVerticalAngleMin, cameraVerticalAngleMax, _controls);        
    }

    void Update()
    {
        _controls.ArtificialUpdate();
        //_playerAttack.ReloadCooldown(Time.deltaTime);
        _playerAttack.ReloadCooldown();

        //esto es por si quiero actualizar valores de la camara
        _cameraFollow.UpdateValues(cameraDistance, aimCameraDistance,
            cameraHeight, cameraRotationSpeed, cameraSensitivity,
            cameraSmoothness, cameraVerticalAngleMin, cameraVerticalAngleMax);
    }
    
    void LateUpdate()
    {
        if (!_activeThisCamera)
        {
        _cameraFollow.LateUpdate();

        //se sincroniza la rotación del personaje con la cámara
        float cameraRotation = _cameraFollow.GetHorizontalRotation();
        _movement.Rotate(cameraRotation);

        }
    }
}
