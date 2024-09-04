using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
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
}