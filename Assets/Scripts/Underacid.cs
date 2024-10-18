using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underacid : MonoBehaviour
{
    public Transform target;
    public bool isOnPool;
    [SerializeField] string floatName;
    public Material underAcidMat; //Modifico el valor Borderstrenght de 0.01 a 0.28 que son los valores que le quedan bien
    public void Update()
    {
        //Saco la diferencia de distancia solamente en Y entre la pileta y el target
        //Si distanceY es mayor a 0 y estoy dentro entonces prendo el postproceso
        //Sino apago el postproceso
        if (isOnPool)
        {
            float distanceY = transform.position.y - target.position.y;
            if (distanceY > 0)
            {
                float borderStrenght = distanceY / 2.576795f;
                underAcidMat.SetFloat(floatName, borderStrenght);
                Debug.Log(distanceY);
            }
        }
        else
        {
            underAcidMat.SetFloat(floatName, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerLife>())
        {
            isOnPool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerLife>())
        {
            isOnPool = false;
        }
    }
}
