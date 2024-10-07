using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekSteering : ISteering
{
    public float radius; // radio de frenado
    private float maxSpeed;// factor de aceleración
    private Vector3 currentVelocity;// velocidad actual
    public SeekSteering(float speed, float radius)
    {
        currentVelocity = Vector3.zero;
        this.maxSpeed = speed;
        this.radius = radius;
    }
    public Vector3 GetDir(Vector3 origin, Vector3 target)
    {
        Vector3 directionToTarget = target - origin;// dirección = posición final - inicial
        Vector3 desiredVelocity = directionToTarget.normalized * maxSpeed;// velocidad deseada = dirección normalizada * aceleración
        Vector3 steering = desiredVelocity - currentVelocity;// corrección de velocidad = velocidad deseada - velocidad actual
        currentVelocity += steering * Time.deltaTime;// a la velocidad actual se le suma la corrección 
        currentVelocity *= Mathf.Clamp01(directionToTarget.magnitude / radius);
        return currentVelocity * Time.deltaTime;
    }
}