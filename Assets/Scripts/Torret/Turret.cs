using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //TurretAttack _turretAttack;
    
        
    public TurretAttack turretAttack;

    public Transform target;
    private bool isTracking = false;

    [Header("Shoot")]


    //public Factory<Bullet> factory;


    //public Transform bulletSpawner;
    //public float cdShoot = 1f;
    //public float cdShootReload = 0f;

    public Transform raycastOrigin;    //punto desde donde se lanza el raycast (el cañón de la torreta)
    [Range(5f, 20f)] public float rotationSpeed;
    [Range(10f, 30f)] public float rayRange; //rango de detección del raycast

    

    //private void Awake()
    //{
    //    _turretAttack = new TurretAttack(cdShoot, cdShootReload, bulletSpawner); //factory
    //}

    private void Update()
    {
        if (isTracking == true)
        {
            RotateTowardsTarget();
            RaycastAndShoot();

            //_turretAttack.ReloadCooldown();
        }
    }

    private void RotateTowardsTarget()
    {
        Vector3 direction = target.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        
        //suavizo la rotacion con un slerp
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void RaycastAndShoot()
    {
        RaycastHit hit;
        Vector3 rayDirection = raycastOrigin.forward * rayRange;

        Debug.DrawLine(raycastOrigin.position, raycastOrigin.position + rayDirection, Color.red);

        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, rayRange))
        {
            //si el objeto que toca el ray tiene la interfaz IDamageable pega el tiro
            //IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            //if (damageable != null)
            //{
            //_turretAttack.Shoot();
            //}


            turretAttack.Shoot();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target.gameObject)
        {
            isTracking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target.gameObject)
        {
            isTracking = false;
        }
    }

    //private void Shoot()
    //{
    //    // Implementa la lógica de disparo
    //    Debug.Log("Disparando al objetivo");
    //}


    /*
    public float cd = 2f;
    public float cdReset;
    public Transform spawner;
    public Transform target;
    public float detectionRange = 50f;
    public bool isTracking;
    public float rotationSpeed = 2f;

    Ray ray;
    RaycastHit raycastHit;

    void Update()
    {
        if (isTracking == true)
        {
        Tracker();
        Shoot();
        }
    }

    bool IsTargetInRange()
    {
        RaycastHit hit;

        // Hacemos un Raycast hacia adelante desde la torreta, con la distancia máxima de 'detectionRange'
        if (Physics.Raycast(spawner.position, spawner.forward, out hit, detectionRange))
        {
            // Verificamos si el objeto golpeado tiene un componente que implemente IDamageable
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                return true;  // Se detectó un objetivo que puede recibir daño
            }
        }

        return false;  // No se detectó ningún objetivo
    }

    private void Start()
    {        
    }

    public void Shoot()
    {
        if (cdReset >= cd)
        {
            //var s = factory.Create(); //creo la bala con la factory
            //s.transform.position = spawner.position;
            //s.transform.rotation = spawner.rotation;
            
            cd = 0;
        }

        else if (cdReset < cd)
            cdReset += Time.deltaTime;
    }

    private void RotateTowardsTarget()
    {
        // Dirección hacia el objetivo
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        // Rotamos la cabeza de la torreta lentamente hacia el objetivo
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }


    public void Tracker()
    {
        transform.transform.rotation = Quaternion.Euler(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        isTracking = !isTracking;
    }

    private void OnTriggerExit(Collider other)
    {
        isTracking = !isTracking;
        cdReset += Time.deltaTime;
    }
    */
}
