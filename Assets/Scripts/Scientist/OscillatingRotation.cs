using UnityEngine;

public class OscillatingRotation : MonoBehaviour
{
    public float rotationAngle = 45f; // Grados a rotar en cada dirección
    public float speed = 2f; // Velocidad de oscilación
    public Vector3 rotationAxis = Vector3.up; // Eje de rotación (por defecto Y)

    private Quaternion startLocalRotation;

    void Start()
    {
        startLocalRotation = transform.localRotation; // Guarda la rotación local inicial
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * rotationAngle;
        Quaternion oscillation = Quaternion.Euler(rotationAxis * angle);
        transform.localRotation = startLocalRotation * oscillation;
    }
}
