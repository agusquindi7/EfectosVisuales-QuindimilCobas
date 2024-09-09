using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour, IEnemyDetection
{
    public Transform player;
    public float detectionRange = 10f;
    public float stopChaseRange = 15f;

    public bool IsPlayerInRange { get; private set; } = false;
    public Transform Player => player;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            IsPlayerInRange = true;
        }
        else if (distanceToPlayer >= stopChaseRange)
        {
            IsPlayerInRange = false;
        }
    }
}