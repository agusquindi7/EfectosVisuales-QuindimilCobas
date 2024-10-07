using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringAgent : MonoBehaviour
{
    [SerializeField] protected float _maxSpeed;
    [SerializeField] protected float _maxForce;
    protected Vector3 _velocity;

    protected Vector3 Seek(Vector3 target)
    {
        Vector3 desired = (target - transform.position).normalized * _maxSpeed;
        return CalculateSteering(desired);
    }

    protected Vector3 CalculateSteering(Vector3 desired)
    {
        Vector3 steering = desired - _velocity;
        return Vector3.ClampMagnitude(steering.IgnoreY(), _maxForce * Time.deltaTime);
    }

    protected void AddForce(Vector3 force)
        => _velocity = Vector3.ClampMagnitude(_velocity + force, _maxSpeed);


    protected void Move()
    {   
        if (_velocity == Vector3.zero) return;
        transform.forward = _velocity;
        transform.position += _velocity * Time.deltaTime;
    }
}
