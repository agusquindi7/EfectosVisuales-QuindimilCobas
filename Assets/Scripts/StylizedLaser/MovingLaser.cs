using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLaser : MonoBehaviour
{
    //Array waypoints, Proximo Waypoint, Ir hacia el waypoint, Chequear si llegue y sumar al index, Repetir
    [SerializeField] int currentWaypointIndex = 0;
    [SerializeField] Transform[] waypoints;
    [SerializeField] float panSpeed;
    [SerializeField] bool isON;

    private void Update()
    {
        if (isON && waypoints.Length > 0)
        {
            Vector3 currentWaypoint = waypoints[currentWaypointIndex].position;
            Vector3 dir = (currentWaypoint - transform.position).normalized;

            transform.position += dir * panSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, currentWaypoint) < 0.1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }
}
