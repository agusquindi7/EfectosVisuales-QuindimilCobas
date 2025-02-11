using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV_Scientist : MonoBehaviour
{
    public Transform parentTransform;
    public LayerMask detectionLayer;
    public bool canSeePlayer = false;

    private void Start()
    {
        if (parentTransform == null)
        {
            parentTransform = transform.root; // Toma el padre raíz si no se asigna
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto tiene el componente PlayerLife
        PlayerLife player = other.GetComponent<PlayerLife>();
        if (player == null) return; // Si no lo tiene, salir del método

        Debug.Log("Tocó al jugador: " + other.name);

        // Obtener la dirección hacia el jugador
        Vector3 direction = (other.transform.position - parentTransform.position).normalized;

        // Hacer un Raycast con LayerMask
        RaycastHit hit;
        if (Physics.Raycast(parentTransform.position, direction, out hit, Mathf.Infinity, detectionLayer))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                Debug.Log("El jugador está detrás de un obstáculo. No puede verlo.");
                canSeePlayer = false;
            }
            else if (hit.collider.GetComponent<PlayerLife>() != null)
            {
                Debug.Log("Jugador detectado, activando canSeePlayer.");
                canSeePlayer = true;
            }
        }
    }
}
