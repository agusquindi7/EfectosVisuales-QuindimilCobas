using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumesAntidote : MonoBehaviour
{
    public bool isTouching = false;
    [SerializeField] float absorvingSpeed = 1;
    [SerializeField] [Range(0, 2)] float fillStart;
    [SerializeField] Renderer liquidWobbleRenderer;
    [SerializeField] ParticleSystem particles;
    [SerializeField] AudioSource asAntidote;

    private Material liquidWobbleMat; // Referencia al material original

    private void Start()
    {
        //if (liquidWobbleRenderer == null) liquidWobbleRenderer = GetComponentInChildren<Renderer>();
        asAntidote.mute = true;
        particles.Stop();
        liquidWobbleMat = liquidWobbleRenderer.material; // Forzar una instancia
        liquidWobbleMat.SetFloat("_Fill", fillStart);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerLife>() && !HasDrankTheAntidote())
        {
            particles.Play();
            isTouching = true;
            asAntidote.mute = false;
        }
    }

    private void Update()
    {
        if (isTouching)
        {
            Debug.Log("Le resto fill");
            float newFill = liquidWobbleMat.GetFloat("_Fill") - (absorvingSpeed * Time.deltaTime);
            newFill = Mathf.Clamp(newFill, -2, fillStart);
            liquidWobbleMat.SetFloat("_Fill", newFill);

            liquidWobbleRenderer.material = liquidWobbleMat;
        }
    }


    public bool HasDrankTheAntidote()
    {
        return liquidWobbleMat.GetFloat("_Fill") <= -1.9;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerLife>())
        {
            particles.Stop();
            isTouching = false;
            asAntidote.mute = true;
        }
    }
}
