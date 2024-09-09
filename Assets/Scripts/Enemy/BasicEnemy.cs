using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicEnemy : Enemy
{
    private IEnemyDetection enemyDetection;

    void Start()
    {
        enemyDetection = GetComponent<IEnemyDetection>();
    }

    void Update()
    {
        if (enemyDetection.IsPlayerInRange)
        {
            RotateTowardsPlayer();
            ChasePlayer();
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = (enemyDetection.Player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }

    private void ChasePlayer()
    {
        Vector3 direction = (enemyDetection.Player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

}