using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbMovDEMO : MonoBehaviour
{
    Rigidbody myRB;
    [SerializeField] float m_Speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        myRB.MovePosition(transform.position + m_Input * Time.fixedDeltaTime * m_Speed);
    }
}
