using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Material zoomMat, aimMat;
    float zoom = 0;
    float aim = -1;
    [SerializeField, Range (0f,1f)] float zoomSpeed;
    [SerializeField, Range(0f, 1f)] float aimSpeed;
    //[SerializeField] KeyCode myCannonKey;

    //private void Awake()
    //{
    //    aimMat.SetFloat("_ScreenBorderAmount", -1f);
    //}

    private void Update()
    {


        if(Input.GetMouseButton(1))
        {
            //Zoom Material
            zoom += (Time.time * zoomSpeed);
            zoom = Mathf.Clamp(zoom,0,0.5f);
            zoomMat.SetFloat("_Zoom", zoom);
            //Aim Material
            aim += (Time.time * aimSpeed);
            aim = Mathf.Clamp(aim, -1, 0.2f);
            aimMat.SetFloat("_ScreenBorderAmount", aim);
        }
        else
        {
            //Zoom Material
            zoom -= (Time.time * zoomSpeed);
            zoom = Mathf.Clamp(zoom, 0, 0.5f);
            zoomMat.SetFloat("_Zoom", zoom);
            //Aim Material
            aim -= (Time.time * aimSpeed);
            aim = Mathf.Clamp(aim, -1, 0.2f);
            aimMat.SetFloat("_ScreenBorderAmount", aim);
        }
    }
}
