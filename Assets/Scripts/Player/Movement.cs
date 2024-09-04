using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Controls playerInput; //podria ponerle Entities para respetar SOLID pero se que solo va a haber 1 control

    void Start()
    {
        playerInput = GetComponent<Controls>();
    }

    void Update()
    {
        Vector3 movement = playerInput.GetMovementInput();
        Move(movement);
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
