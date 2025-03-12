using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabitasAudioTEMP : MonoBehaviour
{
    AudioSource audioBabitas;
    [SerializeField] IsGrounded isGrounded;

    private void Awake()
    {
        if(audioBabitas == null) audioBabitas = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 && isGrounded.isGrounded)
        {
            audioBabitas.mute = false;
        }
        else if (Input.GetAxisRaw("Vertical") != 0 && isGrounded.isGrounded)
        {
            audioBabitas.mute = false;
        }
        else
        {
            audioBabitas.mute = true;
        }
    }
}
