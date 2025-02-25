using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Controls _controls;
    PlayerAttack _playerAttack;
    Movement _movement;
    CameraFollow _cameraFollow;
    AIM _aim;

    [Header("Player")]
    public MonoBehaviour monoBehaviour;
    [SerializeField] Rigidbody rb;
    public float speed = 5f;

    [Space(10)][Header("Rotation")]
    public float rotationSpeed = 10f;

    [Space(10)][Header("Shoot")]
    public Factory<Bullet> factory;
    public Transform bulletSpawner;
    public float cdShoot = 1f;
    public float cdShootReload = 0f;
    public int ammo = 10;
    public GameObject crossPoint;
    
    [Space(10)][Header("Canonball")]
    [Range(10f, 50f)] public float launchForce = 10f;

    public float jumpHeight = 5f;
    public float jumpDistance = 10f;
    public float adjustmentSpeed = 5f; //Velocidad de ajuste para la distancia y altura
    public float minDistance = 2f;
    public float maxDistance = 20f;
    public float minHeight = 1f;
    public float maxHeight = 10f;
    //public float gravity = -9.8f; //ESTO ES PORQUE LA GRAVEDAD NORMAL ANDA MAL Y NO ES EXACTA
    public LayerMask groundLayer;
    public float raycastDistance = 1.5f;
    private bool isJumping = false;
    private Vector3 velocity;

    [Space(10)]
    [Header("LineRenderer Config")]
    public LineRenderer lineRenderer;
    public int maxLineSegments = 30;
    public bool lineShow = false;
        
    [Space(10)][Header("Camera")]    
    [SerializeField] private Camera camera; //referencia de la camara principal
    public float mouseSensitivity = 100;
    [Range(0f, 30f), SerializeField] float distance = 15f;
    public float hitOffSet = 0.1f;
    public float cameraRotationSpeed = 4f;
    
    public Transform rotationYCam;
    
    [SerializeField] bool _cancelThisCamera;

    [Header("MATERIAL AIM")]
    public Material aimShadowsMat; //material
    public string borderFloatRef; //nombre de la referencia

    void Awake()
    {
        rotationSpeed = mouseSensitivity;
        cameraRotationSpeed = rotationSpeed;

        //si inicializo antes los controles hay problemas nulos, queres inicializar algo que no existe
        //_playerAttack = new PlayerAttack(cdShoot, cdShootReload, bulletSpawner, ammo, factory, _controls);
        _playerAttack = new PlayerAttack(cdShoot, cdShootReload, bulletSpawner, ammo, factory, crossPoint);

        //_movement = new Movement(transform, rb, speed, rotationSpeed, bulletSpawner, launchForce, isJumping, jumpHeight, jumpDistance, velocity, lineRenderer, maxLineSegments, lineShow, raycastDistance, groundLayer); //monoBehaviour
        _movement = new Movement(transform, rb, speed, rotationSpeed, bulletSpawner, launchForce, isJumping, velocity, lineRenderer, maxLineSegments, raycastDistance, groundLayer, jumpHeight, jumpDistance,
            adjustmentSpeed, minDistance, maxDistance, minHeight, maxHeight); //monoBehaviour


        _aim = new AIM(aimShadowsMat, borderFloatRef, _movement);
        //_aim = new AIM(aimShadowsMat, borderFloatRef, raycastDistance, groundLayer);

        //_controls = new Controls(_movement, _playerAttack, isJumping);
        _controls = new Controls(_movement, _playerAttack);


        //entonces inicializo un metodo de controls luego de crear controls
        _movement.SetControls(_controls);

        _aim.SetControls(_controls);
        _playerAttack.SetControls(_controls);
        
        //_camerafollow = new camerafollow(transform, cameratransform, cameradistance, aimcameradistance, cameraheight,
        //                                 camerarotationspeed, camerasensitivity, camerasmoothness,
        //                                 cameraverticalanglemin, cameraverticalanglemax, _controls);        

        //_camerafollow = new camerafollow(transform, camera, mousesensitivity,distance, hitoffset,
        //    iscamerablocked, campos, direction, ray, _controls);

        _cameraFollow = new CameraFollow(transform, camera, mouseSensitivity, distance, hitOffSet, _controls, rotationYCam);

    }

    private void Start()
    {
        _cameraFollow.CameraStart();

        //PAUSA
        //ManagerPause.instance.Subscribe(ArtificialUpdate);

    }

    private void FixedUpdate()
    {
        _cameraFollow.CameraFixedUpdate();
        _movement.ArtificialFixedUpdate();
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
        //_playerAttack.ReloadCooldown();
        _playerAttack.ArtificialUpdate();

        _movement.UpdateCannonValues(speed, launchForce);
        _cameraFollow.UpdateValues(distance);
        //_movement.LineView();

        _aim.UpdateAim();

        //isJumping = _movement.GetJump();

        //esto es por si quiero actualizar valores de la camara
        //_cameraFollow.UpdateValues(cameraDistance, aimCameraDistance,
        //    cameraHeight, cameraRotationSpeed, cameraSensitivity,
        //    cameraSmoothness, cameraVerticalAngleMin, cameraVerticalAngleMax);

        _movement.ArtificialdUpdate();
        _cameraFollow.ArtificialUpdate();
    }

    private void OnDrawGizmos()
    {
#if !UNITYEDITOR
        _cameraFollow.OnDrawGizmoscam();
#endif
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, transform.position + Vector3.down * raycastDistance);
    }    
}
