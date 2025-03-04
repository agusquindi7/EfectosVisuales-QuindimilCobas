using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSRainTrigger : MonoBehaviour
{
    public Material fsRain;
    [SerializeField] private string _mask = "_ScreenBorderAmount";
    public GameObject player;

    public float lerpDuration = 1.0f;
    private Coroutine currentCoroutine; //Lo uso para guardar la corrutina, asi si hay una corrutina en proceso pueda pararla y ejecutar la nueva

    private void Awake()
    {
        fsRain.SetFloat(_mask, 20f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Entra al trigger");

            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);

            float currentValue = fsRain.GetFloat(_mask); //Agarro el valor float actual de la mascara 
            currentCoroutine = StartCoroutine(LerpFloat(currentValue, -0.9f, lerpDuration)); //le paso el valor actual, el nuevo valor y la duracion de tiempo a la corrutina

            //fsRain.SetFloat(_mask, -0.9f);
        }  

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Sale del trigger");

            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);

            float currentValue = fsRain.GetFloat(_mask); //Agarro el valor float actual de la mascara 
            currentCoroutine = StartCoroutine(LerpFloat(currentValue, 20f, lerpDuration)); //le paso el valor actual, el nuevo valor y la duracion de tiempo a la corrutina

            //fsRain.SetFloat(_mask, 20);
        }
    }

    private IEnumerator LerpFloat(float startValue, float endValue, float duration)
    {
        float elapsed = 0f; //tiempo actual
        while (elapsed < duration)
        {
            float newValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            fsRain.SetFloat(_mask, newValue);
            elapsed += Time.deltaTime;
            yield return null;
        }
        fsRain.SetFloat(_mask, endValue); //aseguro que sea el valor final


        //float elapsed = 0f;
        //while (elapsed < duration)
        //{
        //    elapsed += Time.deltaTime;
        //    float t = Mathf.Clamp01(elapsed / duration);
        //    //float newValue = Mathf.Lerp(startValue, endValue, t);
        //    float newValue = Mathf.Lerp(startValue, endValue, Mathf.SmoothStep(0f, 1f, t));
        //    fsRain.SetFloat(_mask, newValue);
        //    Debug.Log("nuevo valor: " + newValue);
        //    yield return null;
        //}


        //fsRain.SetFloat(_mask, endValue);
        //Debug.Log("valor final: " + endValue);

        //float currentValue = startValue;
        //float velocity = 1f;
        //float elapsed = 0f;
        //while (elapsed < duration)
        //{
        //    elapsed += Time.deltaTime;
        //    //SmoothDamp ajusta la velocidad para desacelerar cerca del objetivo
        //    currentValue = Mathf.SmoothDamp(currentValue, endValue, ref velocity, duration);
        //    fsRain.SetFloat(_mask, currentValue);
        //    yield return null;
        //}
        //fsRain.SetFloat(_mask, endValue);
    }
}
