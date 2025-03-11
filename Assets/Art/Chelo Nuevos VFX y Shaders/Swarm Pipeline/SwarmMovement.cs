using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SwarmMovement : MonoBehaviour
{
    [SerializeField] private VisualEffect _vfxSwarm;
    [SerializeField] private GameObject _targetSwarm;

    [SerializeField] private Transform targetPositionUp;
    [SerializeField] private Transform targetPositionDown;

    //[SerializeField] private float _speed = 5f;
    [SerializeField] private float _waitTime = 2f;
    [SerializeField] private float _valueForce0 = 0f;
    [SerializeField] private float _valueForce1 = 1f;

    public bool onOff = false;
    public bool canChange;
    private bool lastState; //para almacenar el ultimo estado conocido
    

    private int currentIndex = 0;
    private bool isWaiting = false;

    private void Awake()
    {
        if (targetPositionDown == null || targetPositionUp == null) Debug.Log("falta un target");

    }

    private void Start()
    {
        canChange = true;

        lastState = onOff; //guarda el estado inicial
        if (onOff == false) Off();
        if (onOff == true) On();
    }

    private void Update()
    {
        if (!canChange) return; //Si no puede cambiar, salir de la funcion

        canChange = false; //bloquea cambios mientras se mueve
        onOff = !onOff; //al entrar cambio la variable booleana

        if (onOff) On(); //si el booleano es true prendo
        else Off();

        //if (!isWaiting)
        //{
        //    MoveTarget(); //si no espera se mueve
        //}
    }

    //private void MoveTarget()
    //{
    //    Transform target = _waypoints[currentIndex];
    //    //transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    //    _targetSwarm.transform.position = Vector3.Lerp(_targetSwarm.transform.position, target.transform.position, 2f);
    //    Debug.Log("Se va al siguiente waypoint");

    //    //si el objeto se acerca lo suficiente al waypoint inicia la corrutina de espera
    //    if (Vector3.Distance(_targetSwarm.transform.position, target.position) < 0.1f)
    //    {
    //        _targetSwarm.transform.position = target.position; //me aseguro que este en la misma posicion
    //        StartCoroutine(Waiting());
    //    }
    //}

    //si quisiera mas estados que ON/OFF puedo meter el index y cambiar el material desde ahi
    private void On()
    {
        TargetUp();
    }
    private void Off()
    {
        TargetDown();
    }

    private void TargetUp()
    {
        StartCoroutine(MoveTarget(targetPositionUp));
    }

    private void TargetDown()
    {
        StartCoroutine(MoveTarget(targetPositionDown));
    }

    IEnumerator MoveTarget(Transform targetPosition)
    {
        //float duration = 4f;
        float elapsedTime = 0f;
        Vector3 startPosition = _targetSwarm.transform.position;
        //canChange = false;
        while (elapsedTime < _waitTime)
        {
            float t = elapsedTime / _waitTime;
            _targetSwarm.transform.position = Vector3.Lerp(startPosition, targetPosition.position, t);
            elapsedTime += Time.deltaTime;
            yield return null;

        }
        _targetSwarm.transform.position = targetPosition.position; //aseguro que la posicion final sea exacta

        _vfxSwarm.SetFloat("Force", _valueForce0);
        yield return new WaitForSeconds(3f);
        _vfxSwarm.SetFloat("Force", _valueForce1);

        canChange = true;
        Debug.Log("Se cambio canChange a " + canChange + "al final de la corrutina");
    }

    //IEnumerator Waiting()
    //{
    //    isWaiting = true;
    //    _vfxSwarm.SetFloat("Force", _valueForce1);
    //    yield return new WaitForSeconds(_waitTime);
    //    //if (currentIndex < waypoints.Length - 1)
    //    //{
    //    //    currentIndex++;
    //    //}
    //    //else
    //    //{
    //    //    currentIndex = 0;
    //    //}
    //    //al llegar al ultimo waypoint vuelve a empezar desde el primero
    //    currentIndex = (currentIndex + 1) % _waypoints.Length; //cuento directamente el resto de la division y listo
    //    isWaiting = false;
    //    _vfxSwarm.SetFloat("Force", _valueForce1);
    //}

}
