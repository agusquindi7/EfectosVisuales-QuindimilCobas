using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWaypoints : MonoBehaviour
{
    [SerializeField] Animator[] anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerLife>())
        {
             ActivateLasers();
        }
    }

    private void ActivateLasers()
    {
        foreach (Animator animator in anim)
        {
            animator.SetTrigger("isOn");
        }
    }
}
