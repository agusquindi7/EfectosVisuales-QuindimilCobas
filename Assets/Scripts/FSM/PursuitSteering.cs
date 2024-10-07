using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitSteering : ISteering
{
    SeekSteering ss;// uso un seek de base
    float timePrediction;// tiempo que pienso predecir del movimiento del objetivo
    Vector3 previousTargetPosition;// guardo la posici�n anterior
    public PursuitSteering(float speed, float radius, float timePrediction)
    {
        this.timePrediction = timePrediction;
        ss = new SeekSteering(speed, 0);
    }

    public Vector3 GetDir(Vector3 origin, Vector3 target)
    {
        Vector3 targetDirection = target - previousTargetPosition; // direccion de movimiento = posici�n - posici�n previa
        Vector3 futureTarget = target + targetDirection * timePrediction / Time.deltaTime;// posici�n futura = su posici�n actual + su direcci�n * tiempo de predicci�n 
        previousTargetPosition = target; // actualizo la posici�n previa
        Debug.DrawRay(origin, futureTarget - origin, Color.red);
        return ss.GetDir(origin, futureTarget); // aplico Seek con la posici�n futura
    }
}