using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockKnock : MonoBehaviour
{
    public bool isOnChecker;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "2x4" && !isOnChecker)
        {
            isOnChecker = true;
        }
    }
}
