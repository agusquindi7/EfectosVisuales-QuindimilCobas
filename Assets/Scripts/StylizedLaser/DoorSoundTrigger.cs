using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundTrigger : MonoBehaviour
{
    bool isOpened = false;

    private void OnCollisionEnter(Collision collision)
    {
        //Light light = GetComponentInChildren<Light>();
        
        if (collision.gameObject.GetComponent<Player>() && !isOpened)
        {
            isOpened = true;
            AudioManager.instance.PlayDoorSound();   
        }
    }
}
