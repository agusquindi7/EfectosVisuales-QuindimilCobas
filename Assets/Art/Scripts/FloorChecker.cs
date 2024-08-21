using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChecker : MonoBehaviour
{
    public Rigidbody[] myRBs;

    public void Start()
    {
        myRBs = GameObject.FindObjectsOfType<Rigidbody>();

        //if(myRBs!=null)
        //{
        //    foreach (Rigidbody item in myRBs)
        //    {
        //        myRBs[] = GetComponent<Rigidbody>();
        //    }
        //}
    }
}
