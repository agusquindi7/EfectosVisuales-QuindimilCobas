using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public bool isGrounded;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            isGrounded = false;
        }
    }
}
