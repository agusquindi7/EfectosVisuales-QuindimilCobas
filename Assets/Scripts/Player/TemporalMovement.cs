using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TemporalMovement : MonoBehaviour
{
    public float moveSpeed = 5f;    // Velocidad de movimiento
    public float flySpeed = 3f;     // Velocidad de vuelo
    public float jumpForce = 10f;   // Fuerza de salto
    public float gravityMultiplier = 2f; // Multiplicador de gravedad personalizada

    private Rigidbody rb;
    private bool isFlying = false;  // Estado de vuelo

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactiva la gravedad para controlarla manualmente
    }

    void Update()
    {
        // Movimiento en el plano XZ (WASD o teclas de flechas)
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);

        // Comprobar si se presiona la barra espaciadora para volar
        if (Input.GetKey(KeyCode.Space))
        {
            isFlying = true;
            rb.velocity = new Vector3(rb.velocity.x, flySpeed, rb.velocity.z);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isFlying = false;
        }

        // Aplicar gravedad cuando no esté volando
        if (!isFlying)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (gravityMultiplier - 1) * Time.deltaTime;
        }
    }
}