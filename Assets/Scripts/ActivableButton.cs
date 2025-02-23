using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableButton : MonoBehaviour, IActivable
{
    //public Material[] materials;
    //private int currentMaterialIndex = 0;    
    public Material onMat;
    public Material offMat;
    public bool onOff = true;
    //public GameObject[] doors;
    public GameObject door;
    //Con vector tambien puedo definirlo manualmente, pero con un transform me parece mejor
    //public Vector3[] targetsUp;
    //public Vector3[] targetsDown;
    public Transform targetPositionUp;
    public Transform targetPositionDown;
    //public GameObject[] winds;
    public GameObject windKill;
    public float speed = 5f;
    private Renderer objRenderer;
    public bool canChange;

    private bool lastState; // Para almacenar el último estado conocido


    private void Awake()
    {
        if (targetPositionDown == null || targetPositionUp == null) Debug.Log("falta un target");
        if (door == null) Debug.Log("falta la puerta");
        if (onMat == null || offMat == null) Debug.Log("falta un material");
    }

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
        objRenderer.material = onMat;
        canChange = true;

        lastState = onOff; // Guardar el estado inicial
    }

    public void Activate()
    {
        //if (canChange == false) return;
        //else if (canChange == true)
        //{
        //    canChange = false;
        //    Debug.Log("Se cambio canChange a " + canChange + "en Activate");
        //    onOff = !onOff;
        //    Debug.Log("Se cambio onOff a " + onOff);

        //    if (onOff == false) Off();
        //    else if (onOff == true) On();
        //}

        //Si es falso retorna, si es true pasa; se hace falso, se cambia el booleano de onOff y se ejecuta su metodo en un corrutina. Al final de la corrutina se vuelve a cambiar el booleano canChange
        if (!canChange) return; //Si no puede cambiar, salir de la función

        canChange = false; // Bloquear cambios mientras se mueve
        onOff = !onOff;

        if (onOff) On();
        else Off();

    }

    private void Update()
    {
        if (onOff != lastState) // Si el valor cambió manualmente en el Inspector
        {
            Activate(); // Ejecutar el cambio de estado
            lastState = onOff; // Actualizar el estado guardado
        }
    }

    //si quisiera mas estados que ON/OFF puedo meter el index y cambiar el material desde ahi
    private void On()
    {
        //currentMaterialIndex=1;
        //objRenderer.material = materials[currentMaterialIndex];
        objRenderer.material = onMat;
        DoorUp();
        windKill.SetActive(true);
    }
    private void Off()
    {
        //currentMaterialIndex=0;
        //objRenderer.material = materials[currentMaterialIndex];
        objRenderer.material = offMat;
        DoorDown();
        windKill.SetActive(false);
    }       

    private void DoorUp()
    {
        //OPCION CON FLOAT, CON TARGET Y CON MULTIPLES PUERTAS Y TARGETS
        //    //for (int i = 0; i < doors.Length; i++)
        //    //{
        //    //    doors[i].transform.position = Vector3.MoveTowards(doors[i].transform.position, targetsUp[i], speed * Time.deltaTime);
        //    //}
        StartCoroutine(MoveDoor(targetPositionUp));
    }

    private void DoorDown()
    {
        //door.transform.position = Vector3.MoveTowards(door.transform.position, new Vector3(door.transform.position.x, door.transform.position.y - 10f, door.transform.position.z), 1 * Time.deltaTime);
        //door.transform.position = Vector3.MoveTowards(door.transform.position, targetPositionDown.position, speed * Time.deltaTime);

        StartCoroutine(MoveDoor(targetPositionDown));
        //for (int i = 0; i < doors.Length; i++)
        //{
        //    doors[i].transform.position = Vector3.MoveTowards(doors[i].transform.position, targetsDown[i], speed * Time.deltaTime);
        //}
    }
    IEnumerator MoveDoor(Transform targetPosition)
    {
        float duration = 2f; //Tiempo en segundos
        float elapsedTime = 0f;
        Vector3 startPosition = door.transform.position;
        //canChange = false;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            door.transform.position = Vector3.Lerp(startPosition, targetPosition.position, t);
            elapsedTime += Time.deltaTime;
            yield return null; // Espera un frame antes de continuar
        }        
        door.transform.position = targetPosition.position; //Asegurar que la posición final sea exacta
        canChange = true;
        Debug.Log("Se cambio canChange a " + canChange + "al final de la corrutina");
    }
}
