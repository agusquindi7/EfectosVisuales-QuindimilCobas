using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateview : MonoBehaviour
{
    public float rotationSpeed = 100.0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, mouseX);
    }   
    
}

