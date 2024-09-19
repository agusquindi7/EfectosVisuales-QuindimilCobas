using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicEnemy : Enemy
{
    private IEnemyDetection enemyDetection;
    private IEnemyShooting enemyShooting;
    public float shootInterval = 1f; // Intervalo de tiempo entre disparos
    private float shootTimer;

    void Start()
    {
        enemyDetection = GetComponent<IEnemyDetection>();
        enemyShooting = GetComponent<IEnemyShooting>();
        shootTimer = shootInterval;
    }

    void Update()
    {
        if (enemyDetection.IsPlayerInRange)
        {
            RotateTowardsPlayer();
            ChasePlayer();
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                enemyShooting.Shoot();
                shootTimer = shootInterval;
            }
        }
        else
        {
            shootTimer = shootInterval; // Reinicia el temporizador cuando el jugador no está en rango
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