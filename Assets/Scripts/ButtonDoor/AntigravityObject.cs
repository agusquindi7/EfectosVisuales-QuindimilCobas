using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntigravityObject : MonoBehaviour, IAntigravity
{
    public float antigravitySpeed;
    public Rigidbody rb;
    public bool change = false;
    //public float antigravityMultiplier = 0.5f;

    public void Antigravity()
    {        
        change = !change;
    }

    public void Active()
    {
        if (change == false) return;
        else
        {
            Debug.Log("activando antigravedad");
            rb.useGravity = false;
            transform.position += Vector3.up * antigravitySpeed * Time.deltaTime;
            //rb.useGravity = false;
            //Vector3 upwardForce = Vector3.up * (-Physics.gravity.y * antigravityMultiplier);
            //rb.AddForce(upwardForce, ForceMode.Acceleration);
        }
    }

    void FixedUpdate()
    {
        Active();
    }
}
