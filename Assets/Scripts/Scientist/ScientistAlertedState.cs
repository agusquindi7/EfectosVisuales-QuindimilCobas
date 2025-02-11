using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistAlertedState : ScientistBaseState
{
    public override void OnAwake(FSM_Manager sct)
    {
        sct.tmpro.text = "ALERTED STATE";
        sct.tmpro.color = Color.yellow;
        sct.counter = 0;
        sct.fovMesh.SetActive(true);
    }

    public override void OnUpdate(FSM_Manager sct)
    {
        //Si canSeePlayer es true entonces cambio directamente
        if (sct.fov.canSeePlayer)
        {
            sct.SwitchState(sct.warningState);
        }

        float distanceToWaypoint1 = Vector3.Distance(sct.transform.position, sct.waypoints[0].position); //Distancia hacia waypoint 1
        float distanceToWaypoint2 = Vector3.Distance(sct.transform.position, sct.waypoints[1].position); //Distancia hacia waypoint 2
        if (distanceToWaypoint2 >= 0.1 && sct.counter < sct.timeChecking) //Si no llegue al Waypoint 2 y el contador es menor a el tiempo de chequeo VOY
        {
            sct.transform.position += (sct.waypoints[1].position - sct.transform.position).normalized * Time.deltaTime * sct.speed;
        }
        else if (distanceToWaypoint2 <= 0.1) //Si llegue al waypoint 2 hago correr el tiempo de chequeo
        {
            sct.counter += Time.deltaTime;
            sct.counter = Mathf.Clamp(sct.counter, 0, sct.timeChecking);
        }
        if (distanceToWaypoint1 >= 0.05 && sct.counter == sct.timeChecking) //Si termina el tiempo y estoy lejos del waypoint 1, vuelvo al waypoint 1
        {
            float rotationSpeed = 0.05f;
            Quaternion currentRot = sct.transform.rotation;
            Quaternion targetRot = sct.waypoints[0].transform.rotation;

            sct.transform.rotation = Quaternion.Slerp(currentRot, targetRot, rotationSpeed);

            sct.transform.position += (sct.waypoints[0].position - sct.transform.position).normalized * Time.deltaTime * sct.speed;

            if (distanceToWaypoint1 <= 0.2) //Si llego al waypoint 1 cambio a Idle de vuelta
            {
                sct.SwitchState(sct.idleState);
            } 
        }
    }

    public override void OnExit(FSM_Manager scientist)
    {

    }
}
