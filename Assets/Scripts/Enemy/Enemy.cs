using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 5f;

    private IEnemyDetection enemyDetection;
    private IEnemyShooting enemyShooting;

    void Awake()
    {
        enemyDetection = GetComponent<IEnemyDetection>();
        enemyShooting = GetComponent<IEnemyShooting>();
    }

    public void TakeDamage(float amount)
    {

        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }


}
