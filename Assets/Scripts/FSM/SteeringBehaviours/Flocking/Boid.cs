using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : SteeringAgent
{
    [SerializeField] float _viewRadius;
    [SerializeField] float _separationRadius;
    FlockManager FM => FlockManager.Instance;

    //Weighted Behaviors
    [SerializeField, Range(0f, 3f)] float _separationWeight = 1f;
    [SerializeField, Range(0f, 1f)] float _cohesionWeight = 1f;
    [SerializeField, Range(0f, 1f)] float _alignmentWeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        FM.AddBoid(this);
        Vector3 dir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        AddForce(dir.normalized * _maxSpeed);
    }

    void Update()
    {
        Flocking();
        Move();
        transform.position = FM.GetPositionInBounds(transform.position);
    }

    void Flocking()
    {
        //Combined Behaviors
        AddForce(Separation(_separationRadius) * _separationWeight
            + Cohesion() * _cohesionWeight
            + Alignment() * _alignmentWeight);

        //Leader Following
        //Arrive(Lider) + Separation
    }

    Vector3 Separation(float radius)
    {
        Vector3 desired = Vector3.zero;
        int count = 0;
        foreach (var item in FM.AllBoids)
        {
            if (item == this) continue;
            Vector3 dir = item.transform.position - transform.position;
            if (dir.sqrMagnitude > radius * radius) continue;
            count++;
            desired += dir;
        }
        if (count == 0) return desired;
        desired /= count;
        desired *= -1;

        return CalculateSteering(desired.normalized * _maxSpeed);
    }

    Vector3 Cohesion()
    {
        var desired = Vector3.zero;
        int count = 0;
        foreach (var item in FM.AllBoids)
        {
            if (item == this) continue;
            if (Vector3.Distance(transform.position, item.transform.position) > _viewRadius) continue;
            count++;
            desired += item.transform.position;
        }
        if (count == 0) return desired;
        desired /= count;

        return Seek(desired);
    }

    Vector3 Alignment()
    {
        Vector3 desired = Vector3.zero;
        int count = 0;
        foreach (var item in FM.AllBoids)
        {
            if (item == this) continue;
            if (Vector3.Distance(transform.position, item.transform.position) > _viewRadius) continue;
            count++;
            desired += item._velocity;
        }
        if (count == 0) return desired;


        return CalculateSteering(desired.normalized * _maxSpeed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _viewRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _separationRadius);
    }

}
