using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Vector3 GetMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector3(horizontal, 0, vertical);
    }

    public bool IsAttacking()
    {
        return Input.GetButtonDown("Fire1");
    }

    public bool IsAiming()
    {
        return Input.GetMouseButton(1); //mantengo click derecho para apuntar, eso habilita el aim
    }

    //public Vector3 GetMovementInput()
    //{
    //    float horizontal = Input.GetAxis("Horizontal");
    //    float vertical = Input.GetAxis("Vertical");
    //    return new Vector3(horizontal, 0, vertical);
    //}

    //public bool IsAttacking()
    //{
    //    return Input.GetButtonDown("Fire1");
    //}
}
