using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class StylizedLaser : MonoBehaviour
{
    [Header("Laser")]
    public VisualEffect vfx;
    public float count = 5;
    public float timeToDeactivate,timeToActiveLaser = 3.5f;
    float currentCount;
    public GameObject hitbox;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    private void Start()
    {
        hitbox.SetActive(false);
    }

    private void Update()
    {
        currentCount = Mathf.Clamp(currentCount + Time.deltaTime, 0, count);
        //Debug.Log(currentCount);
        if (currentCount == count)
        {
            currentCount = 0;
            StartCoroutine(ShootLaser());
        }
    }
    
    IEnumerator ShootLaser()
    {
        audioSource.PlayOneShot(clip, 1f);
        yield return new WaitForSeconds(timeToActiveLaser);
        vfx.SendEvent("OnPlay");
        hitbox.SetActive(true);
        yield return new WaitForSeconds(timeToDeactivate);
        hitbox.SetActive(false);
    }
}
