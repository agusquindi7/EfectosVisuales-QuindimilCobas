using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Controls _controls;
    PlayerAttack _playerAttack;
    Movement _movement;
    CameraFollow _cameraFollow;
        
    [Header("Player")] 
    public MonoBehaviour monoBehaviour;
    [SerializeField] Rigidbody rb;
    public float speed = 5f;
    public float forceJump = 3f;

    [Header("Rotation")]
    public float rotationSpeed = 10f;

    [Header("Shoot")]
    public Factory<Bullet> factory;
    public Transform bulletSpawner;
    public float cdShoot = 1f;
    public float cdShootReload = 0f;
    public int ammo = 10;

    [Header("Canonball")]
    public float launchForce = 10f;
    
    [Header("Camera")]    
    [SerializeField] private Camera camera; //referencia de la camara principal
    public float mouseSensitivity = 100;
    [Range(0f, 30f), SerializeField] float distance = 15f;
    public float hitOffSet = 0.1f;
    public float cameraRotationSpeed = 4f;
    //public bool isCameraBlocked;
    //public Vector3 camPos;
    //public Vector3 direction;
    //public Ray ray;

    [SerializeField] bool _cancelThisCamera;

    void Awake()
    {
        rotationSpeed = mouseSensitivity;
        cameraRotationSpeed = rotationSpeed;

        //si inicializo antes los controles hay problemas nulos, queres inicializar algo que no existe
        _playerAttack = new PlayerAttack(cdShoot, cdShootReload, bulletSpawner, ammo, factory);
        _movement = new Movement(transform, rb, speed, forceJump, rotationSpeed, launchForce); //monoBehaviour
        _controls = new Controls(_movement, _playerAttack);

        //entonces inicializo un metodo de controls luego de crear controls
        _movement.SetControls(_controls);

        //_camerafollow = new camerafollow(transform, cameratransform, cameradistance, aimcameradistance, cameraheight,
        //                                 camerarotationspeed, camerasensitivity, camerasmoothness,
        //                                 cameraverticalanglemin, cameraverticalanglemax, _controls);        

        //_camerafollow = new camerafollow(transform, camera, mousesensitivity,distance, hitoffset,
        //    iscamerablocked, campos, direction, ray, _controls);

        _cameraFollow = new CameraFollow(transform, camera, mouseSensitivity, distance, hitOffSet, _controls);

    }

    private void Start()
    {
        _cameraFollow.CameraStart();
    }

    private void FixedUpdate()
    {
        _cameraFollow.CameraFixedUpdate();
    }

    void LateUpdate()
    {
        if (!_cancelThisCamera)
        {
        _cameraFollow.CameraLateUpdate();

        //se sincroniza la rotaci�n del personaje con la c�mara
        //float cameraRotation = _cameraFollow.GetHorizontalRotation();
        //_movement.Rotate(cameraRotation);

        }
    }

    void Update()
    {
        _controls.ArtificialUpdate();
        _playerAttack.ReloadCooldown();

        //esto es por si quiero actualizar valores de la camara
        //_cameraFollow.UpdateValues(cameraDistance, aimCameraDistance,
        //    cameraHeight, cameraRotationSpeed, cameraSensitivity,
        //    cameraSmoothness, cameraVerticalAngleMin, cameraVerticalAngleMax);
    }
    

    

}