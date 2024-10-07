using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekSteering : ISteering
{
    public float radius; // radio de frenado
    private float maxSpeed;// factor de aceleraci�n
    private Vector3 currentVelocity;// velocidad actual
    public SeekSteering(float speed, float radius)
    {
        currentVelocity = Vector3.zero;
        this.maxSpeed = speed;
        this.radius = radius;
    }
    public Vector3 GetDir(Vector3 origin, Vector3 target)
    {
        Vector3 directionToTarget = target - origin;// direcci�n = posici�n final - inicial
        Vector3 desiredVelocity = directionToTarget.normalized * maxSpeed;// velocidad deseada = direcci�n normalizada * aceleraci�n
        Vector3 steering = desiredVelocity - currentVelocity;// correcci�n de velocidad = velocidad deseada - velocidad actual
        currentVelocity += steering * Time.deltaTime;// a la velocidad actual se le suma la correcci�n 
        currentVelocity *= Mathf.Clamp01(directionToTarget.magnitude / radius);
        return currentVelocity * Time.deltaTime;
    }
}