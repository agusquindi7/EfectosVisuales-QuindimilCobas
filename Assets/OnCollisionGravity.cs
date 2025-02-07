using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionGravity : MonoBehaviour
{
    Rigidbody myRB;
    private void Awake()
    {
        if (myRB == null) myRB = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            myRB.useGravity = true;
        }
    }
}
