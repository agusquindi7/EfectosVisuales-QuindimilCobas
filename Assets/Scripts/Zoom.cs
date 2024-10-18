using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Material zoomMat;
    float zoom = 0;
    [SerializeField, Range (0f,1f)] float zoomSpeed;
    [SerializeField] KeyCode myCannonKey;
 
    private void Update()
    {


        if(Input.GetKey(myCannonKey))
        {
            zoom += (Time.time * zoomSpeed);
            zoom = Mathf.Clamp(zoom,0,0.5f);
            Debug.Log(zoom);
            zoomMat.SetFloat("_Zoom", zoom);
        }
        else
        {
            zoom -= (Time.time * zoomSpeed);
            zoom = Mathf.Clamp(zoom, 0, 0.5f);
            Debug.Log(zoom);
            zoomMat.SetFloat("_Zoom", zoom);
        }
    }
}
