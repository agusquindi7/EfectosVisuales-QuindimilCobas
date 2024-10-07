using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePatrolState : SphereBaseState
{
    public override void Awake(SphereStateManager sphere)
    {
        Debug.Log("TRABAJO MUY DURO COMO UN ESCLAVO...");
    }

    public override void Execute(SphereStateManager sphere)
    {
        if (sphere.energy > 0 && sphere.waypoints.Length > 0)
        {   
            //Establezco el waypoint al que tengo que ir y saco su direccion con respecto a mi posicion
            Vector3 currentWaypoint = sphere.waypoints[sphere.currentWaypointIndex].position;
            Vector3 direction = (currentWaypoint - sphere.transform.position).normalized;

            //Sumo mi posicion mas un vector direccion, time y velocidad que saco de manager
            sphere.transform.position += direction * Time.deltaTime * sphere.speed;

            //Si llegue a currentWaypoint...
            if (Vector3.Distance(sphere.transform.position, currentWaypoint) < 0.1f)
            {
                // Pasa al siguiente waypoint y se asegura de reiniciar
                //Sumo 1 al indice, al llegar a 4 por ej se reinicia ya que 4 % 4 = 0
                sphere.currentWaypointIndex = (sphere.currentWaypointIndex + 1) % sphere.waypoints.Length;
            }

            sphere.energy -= Time.deltaTime;
        }
        else if(sphere.energy<=0)
        {
            sphere.SwitchState(sphere.idleState);
        }
        //Chequeo si estoy dentro del rango de chase
        Collider[] colliders = Physics.OverlapSphere(sphere.transform.position, sphere.radius);
        foreach (Collider collider in colliders)
        {
            Debug.Log(collider.name);
            if (collider.GetComponent<PlayerLife>() && Vector3.Distance(collider.transform.position, sphere.transform.position) < sphere.radius)
            {
                sphere.SwitchState(sphere.chaseState);
            }
        }
    }

    public override void Sleep(SphereStateManager sphere)
    {
        Debug.Log("la makina del chambeo en mantenimiento");
    }
}
