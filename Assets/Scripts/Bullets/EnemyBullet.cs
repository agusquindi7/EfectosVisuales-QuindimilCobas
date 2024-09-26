using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public static void TurnOn(EnemyBullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    public static void TurnOff(EnemyBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}